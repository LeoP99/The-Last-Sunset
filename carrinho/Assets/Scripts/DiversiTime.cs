using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiversiTime : MonoBehaviour
{
    // Start is called before the first frame update

    public KeyCode teclarevesetime = KeyCode.C; // variavel usada para usar a volta no tempo
    public float frequencia_Hz = 30; // frequencia de frames usada
    public int maxframes = 100; 
    [Space(15)] // espaco no serialize do unity 
    public bool fixedUpdate_50Hz = false;
    //
    float freq; // private 
    float cronometro;
    bool reverseTime = false;

    List<Vector3> posicoes = new List<Vector3>(); // lista de vetores do tipo 3 chamada de posicoes que guarda cada posicao que o personagem ando
    List<Quaternion> rotacoes = new List<Quaternion>();// guarda a rotacao
    List<Vector3> rbVelocity =  new List<Vector3>(); // guarda a velocidade 
    List<Vector3> rbAngularVelocity = new List<Vector3>(); // guarda angulo e velocidade
    Rigidbody rb;

    

    void Start()
    {
        freq = 1 / frequencia_Hz; 
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // caso o botao C for apertado 

        if (Input.GetKeyDown(teclarevesetime)) {

            if (posicoes.Count > 1 && rotacoes.Count > 1) //se na lista posicao ja tiver gravado mais de um e na rotacao tbm 
            {
                reverseTime = true; // volta no tempo
                if(rb) // se tem rigidbody
                {
                    rb.useGravity = false; //desativa a gravidade 
                }
            }
        }

        if(Input.GetKeyUp(teclarevesetime)) //  se soltar botao 
        {
            reverseTime = false; // desativa a reversao do tempo
            if(rb) // se tem rigidbody 
            {
                rb.useGravity = true; // volta a gravidade 
                rb.velocity = rbVelocity[rbVelocity.Count - 1]; // faz voltar no tempo real
                rb.angularVelocity = rbAngularVelocity[rbAngularVelocity.Count - 1]; // faz voltar no tempo pelo angulo e velocidade real
            }

        }
       if(!fixedUpdate_50Hz) // velocidade dos frames aumentada / grava menos frames
       {
            cronometro += Time.deltaTime;
            if(cronometro >= freq)
            {
                cronometro = 0;
            }
            ChecarReverseTime();
       }

       if(reverseTime) 
        {
            transform.position = Vector3.Lerp(transform.position, posicoes[posicoes.Count - 1], Time.deltaTime * 5.0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacoes[rotacoes.Count - 1], Time.deltaTime * 5.0f);
        }
    }


    private void FixedUpdate()
    {
        if(fixedUpdate_50Hz)
        {

            ChecarReverseTime();
        }

        if(rb)
        {
            if(reverseTime)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    void ChecarReverseTime()
    {
        if(!reverseTime )
        {
            posicoes.Add(transform.position);
            rotacoes.Add(transform.rotation);
            //
            if(rb)
            {
                rbVelocity.Add(rb.velocity);
                rbAngularVelocity.Add(rb.angularVelocity);
            }


            if(posicoes.Count > 100)
            {

                posicoes.Remove(posicoes[0]);
                rotacoes.Remove(rotacoes[0]);
                if(rb)
                {
                    rbVelocity.Remove(rbVelocity[0]);
                    rbAngularVelocity.Remove(rbAngularVelocity[0]);

                }
            }
            
        }
        else
        {
            if(posicoes.Count > 1)
            {
                posicoes.Remove(posicoes[posicoes.Count - 1]);
                rotacoes.Remove(rotacoes[rotacoes.Count - 1]);
                if (rb)
                {
                    rbVelocity.Remove(rbVelocity[rbVelocity.Count -1]);
                    rbAngularVelocity.Remove(rbAngularVelocity[rbAngularVelocity.Count - 1]);

                }
            }
        }
    }

}
