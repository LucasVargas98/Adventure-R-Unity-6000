using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    public GameObject game_camera;

    void Awake(){
        game_camera.SetActive(false);
    }


    //Ontrigger usado para ativar e desativar a Camera quando o cavaleiro entra na Sala
     void OnTriggerEnter2D(Collider2D col){

    if(col.gameObject.tag == "Player"){
        game_camera.SetActive(true);

    }
     }
     void OnTriggerExit2D(Collider2D col){
        
        if(col.gameObject.tag == "Player"){
        game_camera.SetActive(false);

    }
     }
}
