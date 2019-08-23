using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Veiculo : MonoBehaviour
{
    public Transform[] MeshRodas;
    public WheelCollider[] ColisorRodas;
    public float secrio = 1000, pesoVeiculo = 1500;
    private float angulo, direcao;
    private Rigidbody corpoRigido;
    void Start()
    {
        corpoRigido = GetComponent<Rigidbody>();
        corpoRigido.mass = pesoVeiculo;
    }
    void Update()
    {
        direcao = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") > 0.7f || Input.GetAxis("Horizontal") < -0.7f)
        {
            angulo = Mathf.Lerp(angulo, direcao, Time.deltaTime * 4);
        }
        else
        {
            angulo = Mathf.Lerp(angulo, direcao, Time.deltaTime * 2);
        }
    }
    void FixedUpdate()
    {
        ColisorRodas[0].steerAngle = angulo * 40;
        ColisorRodas[1].steerAngle = angulo * 40;
        //
        ColisorRodas[2].motorTorque = Input.GetAxis("Vertical") * secrio;
        ColisorRodas[3].motorTorque = Input.GetAxis("Vertical") * secrio;

        for (int x = 0; x < ColisorRodas.Length; x++)
        {
            Quaternion quat;
            Vector3 pos;
            ColisorRodas[x].GetWorldPose(out pos, out quat);
            MeshRodas[x].position = pos;
            MeshRodas[x].rotation = quat;
        }
    }
}