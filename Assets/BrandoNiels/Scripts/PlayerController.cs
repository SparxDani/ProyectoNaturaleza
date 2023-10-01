using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    List<BasuraController> basurasRecogidas = new List<BasuraController>();
    [SerializeField] List<BasuraController> basurasgenerales = new List<BasuraController>();
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Basura")){
            basurasRecogidas.Add(other.gameObject.GetComponent<BasuraController>());
        }
        if(other.CompareTag("Recojedor")){
            ReciclarBasura(other.gameObject);
        }
    }
    void ReciclarBasura(GameObject recojedor){
        string nameRecojedor = recojedor.GetComponent<TachoController>().name;
        if(nameRecojedor == "Recojedor1"){
            BuscarBasura("basura1",recojedor.transform);
        }else if(nameRecojedor == "Recojedor2"){
            BuscarBasura("basura2",recojedor.transform);
        }else if(nameRecojedor == "Recojedor3"){
            BuscarBasura("basura3",recojedor.transform);
        }
    }
    void BuscarBasura(string nombreBasura,Transform positionTacho){

        BasuraController basuraEncontrada = null;

        for (int i = 0; i < basurasRecogidas.Count; i++)
        {
            if (basurasRecogidas[i].nombre == nombreBasura)
            {
                basuraEncontrada = basurasRecogidas[i];
                basuraEncontrada.transform.position = Vector3.MoveTowards(basuraEncontrada.transform.position, positionTacho.position, 3 * Time.deltaTime);
                basurasRecogidas.RemoveAt(i);
                basuraEncontrada.gameObject.SetActive(false);
            }
        }
    }
}
