using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Range(5f,200f)]
    [SerializeField] private float velocidade;
    [SerializeField] private Rigidbody carro;
    private Vector3 movimento;
    private float posH;
    [SerializeField] private GameObject[] ini;
    private float rotationY = 0f;
    private float sensitiveY = 1f;

    public KeyCode e = KeyCode.LeftArrow;
    public KeyCode d = KeyCode.RightArrow;

    public Vector3 Tcarro;
    
    

    // Start is called before the first frame update
    void Start()
    {
        carro = GetComponent<Rigidbody>();
        Tcarro = transform.localEulerAngles;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        posH = Input.GetAxis("Horizontal");
        

        movimento = new Vector3(posH, 0f, 0f);
        carro.AddForce(movimento * velocidade);


  

        
        if (!Input.GetKey(e) && !Input.GetKey(d))
        {
            rotationY = 0;
            transform.localEulerAngles = Tcarro;


        }
        
        if (Input.GetKey(e) || Input.GetKey(d))
        {

            rotationY += Input.GetAxis("Horizontal") * sensitiveY;
            rotationY = Mathf.Clamp(rotationY, -9, 9);

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationY, transform.localEulerAngles.z);
        }
    }




   /* private void Move (int direcao)
    {

        posCar += direcao;
        if(posCar == 0)
        {
            carro.transform.position.Set(-1.6f, carro.transform.position.y, carro.transform.position.z);

        }
        else if(posCar == 1)
        {
            carro.transform.position.Set(0.07f, carro.transform.position.y, carro.transform.position.z); 
        }
        else
        {
            carro.transform.position.Set(1.7f, carro.transform.position.y, carro.transform.position.z);
        }
    }
    */
}



