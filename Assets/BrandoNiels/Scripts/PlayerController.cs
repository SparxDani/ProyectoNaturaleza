using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    List<BasuraController> basurasRecogidas = new List<BasuraController>();
    [SerializeField] List<BasuraController> basurasgenerales = new List<BasuraController>();
    GeneradorBasuraController generadorBasuraController;
    [SerializeField] float speed;
    public float horizontal, vertical;
    bool horizontalBoolN,horizontalBoolP=false;
    bool verticalBoolN,verticalBoolP=false;
    Rigidbody2D rb2d;
    
    
    private void Awake() {
        rb2d=GetComponent<Rigidbody2D>();
    }
    void Update() {
        InputMovement();
        if(horizontalBoolN){
            horizontal=-1;
        }else if(horizontalBoolP){
            horizontal=1;
        }
        if(verticalBoolN){
            vertical=-1;
        }else if(verticalBoolP){
            vertical=1;
        }
    }
    private void FixedUpdate() {
        
        Movemet();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Basura")){
            other.gameObject.SetActive(false);
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
        }else if(nameRecojedor == "Recojedor4"){
            BuscarBasura("basura4",recojedor.transform);
        }
        
    }
    void BuscarBasura(string nombreBasura,Transform positionTacho){

        BasuraController basuraEncontrada = null;

        for (int i = 0; i < basurasRecogidas.Count; i++)
        {
            if (basurasRecogidas[i].nombre == nombreBasura)
            {
                basuraEncontrada = basurasRecogidas[i];
                basuraEncontrada.gameObject.SetActive(true);
                basuraEncontrada.transform.position = Vector3.MoveTowards(basuraEncontrada.transform.position, positionTacho.position, 3 * Time.deltaTime);
                basurasRecogidas.RemoveAt(i);
                basuraEncontrada.gameObject.SetActive(false);
            }
        }
    }
    void InputMovement(){
        if(horizontal==0){
            vertical = Input.GetAxis("Vertical");
        }
        if(vertical==0){
            horizontal = Input.GetAxis("Horizontal");
        }
    }
    void Movemet(){
        rb2d.velocity=new Vector2(horizontal*speed,vertical*speed);
    }
    public void ClickLeft(){
        horizontalBoolN = true;
    }
    public void ReleaseHorizontal(){
        horizontalBoolP = false;
        horizontalBoolN =false;
    }
    public void ClickRight(){
        horizontalBoolP = true;
    }


    
    public void ClickUp(){
        verticalBoolP = true;
    }
    public void ReleaseVertical(){
        verticalBoolP = false;
        verticalBoolN =false;
    }
    public void ClickDownd(){
        verticalBoolN = true;
    }
}
