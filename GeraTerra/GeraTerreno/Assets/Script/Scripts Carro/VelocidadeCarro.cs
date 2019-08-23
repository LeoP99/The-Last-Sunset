using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadeCarro : MonoBehaviour
{

    [SerializeField] Rigidbody carro;
    [SerializeField] float Velocidade = 10f;


    // Start is called before the first frame update
    void Start()
    {
        carro = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        carro.AddForce(new Vector3(0, 0, 1) * Velocidade * -1);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }



}
