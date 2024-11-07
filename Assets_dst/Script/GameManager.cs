using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <Objetivo>
///  Objetivo básico do script é comandar regras simples do jogo
/// </summary>
public class GameManager : MonoBehaviour
{
    public GameObject player; 

    //sinalizar que o player tem o item
    public bool item_collected;

    public string actual_scene;

    // inicia antes do proprio joho
    void Awake()
    {   

    //Ignorar as físicas de alguns objetos    
    Physics2D.IgnoreLayerCollision(9,7,true);
    Physics2D.IgnoreLayerCollision(3,7,true);
    Physics2D.IgnoreLayerCollision(9,11,true);
    }

    void FixedUpdate(){

        if(Input.GetButtonDown("Exit")){
            Application.Quit(); //Sair do jogo
        }

        if(Input.GetButtonDown("Restart")){
            SceneManager.LoadScene("SampleScene"); //resetar a Scene atual
        }
    }


}
