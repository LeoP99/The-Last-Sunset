using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esteira : MonoBehaviour
{
    //ArrayList objetos = new ArrayList();
    Renderer rend;
    [SerializeField] private float velocidadeTexturaY;
    [SerializeField] private float velocidadeTexturaX;
    [SerializeField] private Transform esteira ;

    // Start is called before the first frame update
    void Awake()
    {
        rend = esteira.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rend.materials[0].SetTextureOffset("_MainTex",new Vector2(velocidadeTexturaX, velocidadeTexturaY) * Time.time *-1);
    }
}
