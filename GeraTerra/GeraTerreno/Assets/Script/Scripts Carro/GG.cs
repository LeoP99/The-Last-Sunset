using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GG : MonoBehaviour
{
    // Start is called before the first frame update

    public static GG instancia;

    [SerializeField] GameObject[] post;
    [Space(15)]
    [SerializeField] GameObject[] ini;
    [SerializeField] Transform[] referencia;
    [Space(15)]
    [SerializeField] Transform[] refPost;

    float velocidad = 2f;

    void Awake()
    {
        if (instancia == null)
            instancia = this;
        else if (instancia != this)
            Destroy(this);
    }


    private void Start()
    {
        Invoke ("Gera", Random.Range(1, 6));
        Invoke("GeraPost",2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    void GeraPost()
    {
        Instantiate(post[Random.Range(0, post.Length)], refPost[Random.Range(0, refPost.Length)].position, Quaternion.identity);
        Invoke("GeraPost", 2);
    }


    void Gera ()
    {
        Instantiate(ini[Random.Range(0, ini.Length)], referencia[Random.Range (0, referencia.Length)].position, Quaternion.identity);
        Invoke ("Gera", Random.Range(1, 4));
       
    }
}
