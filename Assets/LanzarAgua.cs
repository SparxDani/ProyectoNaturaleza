using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class LanzarAgua : MonoBehaviour
{
    bool activarAgua = false;
    [SerializeField] Camera cam;
    Vector2 MousePosicion;

    bool unLanzamiento = true;
    float cadencia;

    [SerializeField] GameObject GloboDeAgua;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (unLanzamiento == false)
        {
            cadencia += Time.deltaTime;
        }

        if (cadencia > 1)
        {
            unLanzamiento = true;
        }

    }


    public void lanzarAgua()
    {
        if (activarAgua == true)
        {
            activarAgua = false;
        }
        else
        {
            activarAgua = true;
        }
    }

    public void Posicion_mouse(InputAction.CallbackContext value)
    {
        MousePosicion = value.ReadValue<Vector2>();
        MousePosicion = cam.ScreenToWorldPoint(MousePosicion);
        //Debug.Log(MousePosicion);
    }


    public void lanar_agua(InputAction.CallbackContext value)
    {
        if(activarAgua == true)
        {
            if (unLanzamiento == true)
            {
                float clic = value.ReadValue<float>();
                if (clic == 1)
                {
                    GameObject globo = Instantiate(GloboDeAgua, transform.position, Quaternion.identity);
                    globo.GetComponent<globo>().Direccion = MousePosicion;
                    unLanzamiento = false;
                    cadencia = 0;
                }
            }
        }
    }



}
