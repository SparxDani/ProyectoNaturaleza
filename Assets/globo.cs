using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globo : MonoBehaviour
{
    [SerializeField]float velocidad;
    Vector2 direccion;

    bool x;
    bool xx;
    bool y;
    bool yy;
    bool coliciono = false;


    float duracion=0;
    [SerializeField]SpriteRenderer spriteRenderer;
    [SerializeField]Rigidbody2D MyRigidbody2D;


    public Vector2 Direccion
    {
        get { return direccion; }
        set { direccion = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < direccion.x)
        {
            x = true;
        }
        else
        {
            x = false;
        }
        if (transform.position.y < direccion.y)
        {
            y = true;
        }
        else
        {
            y = false;
        }
        Debug.Log(x);
        Debug.Log(y);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(coliciono);
        Debug.Log(direccion);
        Debug.Log(transform.position);
        if (coliciono == false)
        {
            MyRigidbody2D.velocity = new Vector2(direccion.x - transform.position.x, direccion.y - transform.position.y).normalized * velocidad * Time.deltaTime;
            


            if (transform.position.x < direccion.x)
            {
                xx = true;
            }
            else
            {
                xx = false;
            }
            if (transform.position.y < direccion.y)
            {
                yy = true;
            }
            else
            {
                yy = false;
            }



            if (x != xx & y != yy)
            {
                impacto();
            }



        }
        else
        {
            duracion += Time.deltaTime;






        }

        
    }



    void impacto()
    {
        coliciono = true;
        spriteRenderer.sprite = null;
        MyRigidbody2D.velocity = Vector2.zero;
    }


}
