using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    Vector2 mousePosition;
    bool coliciona_con_boton = false;



    public bool Coliciona_con_boton
    {
        get { return coliciona_con_boton; }
        set { coliciona_con_boton = value; }
    }
    public Vector2 MousePosition
    {
        get { return mousePosition; }
        set { mousePosition = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = MousePosition;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("boton"))
        {
            coliciona_con_boton = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("boton"))
        {
            coliciona_con_boton = false;
        }
        Debug.Log("DEJO DE COLICIONAR");
    }
}
