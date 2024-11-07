using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Change : MonoBehaviour
{

     //Pegar o Sprite Renderer do Player para fazer a alteração das cores do cavaleiro
    private SpriteRenderer sprite_player;

    // Start is called before the first frame update
    void Start()
    {
        sprite_player = GetComponentInChildren<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col){

    //Alterar a cor do Sprite de acordo com a sala que o cavaleiro se encontra;
    //Para alterar a cor do Sprite será necessário dividir o valor da cor por 255.0f
    
        if(col.gameObject.tag == "Yellow_Room"){
            sprite_player.color = new Color 
            (210.0f/255.0f,
            210.0f/255.0f,
            64.0f/255.0f);
        }

        if(col.gameObject.tag == "Green_Room"){
            sprite_player.color = new Color 
            (92.0f/255.0f,
            186.0f/255.0f,
            92.0f/255.0f);
        }

        if(col.gameObject.tag == "Blue_Room"){
            sprite_player.color = new Color 
            (66.0f/255.0f,
            72.0f/255.0f,
            200.0f/255.0f);
        }

    }
}
