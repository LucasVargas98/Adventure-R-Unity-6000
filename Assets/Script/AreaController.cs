using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
   [SerializeField] private GameObject game_camera;
   //[SerializeField] private GameObject roomActual;

    void Awake(){
        game_camera.SetActive(false);
        //roomActual.SetActive(false);
    }


    //Ontrigger usado para ativar e desativar a Camera quando o cavaleiro entra na Sala
     void OnTriggerEnter2D(Collider2D col){

    if(col.gameObject.tag == "Player"){
        game_camera.SetActive(true);
        //roomActual.SetActive(true);
    }
     }
     void OnTriggerExit2D(Collider2D col){
        
        if(col.gameObject.tag == "Player"){
        game_camera.SetActive(false);
        //roomActual.SetActive(false);
    }
     }
}
