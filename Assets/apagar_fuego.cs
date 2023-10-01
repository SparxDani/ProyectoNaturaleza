using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apagar_fuego : MonoBehaviour
{
    [SerializeField] int vida_del_fuego = 6;

    [SerializeField] ParticleSystem particula1;
    [SerializeField] ParticleSystem particula2;
    [SerializeField] ParticleSystem particula3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vida_del_fuego <= 0)
        {
            terminarFuego();
        }
    }


    public void terminarFuego()
    {
        var mainModule1 = particula1.main;
        var mainModule2 = particula2.main;
        var mainModule3 = particula3.main;
        mainModule1.loop = false;
        mainModule2.loop = false;
        mainModule3.loop = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("1");
        if (collision.CompareTag("agua"))
        {
            Debug.Log("2");
            vida_del_fuego--;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("1");
        if (collision.CompareTag("agua"))
        {
            if (collision.GetComponent<globo>().Coliciono == true)
            {
                Debug.Log("2");
                vida_del_fuego-=1;
                collision.GetComponent<globo>().Coliciono = false;
            }
        }
    }

}
