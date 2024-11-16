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
        sprite_player = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col){

    //Alterar a cor do Sprite de acordo com a sala que o cavaleiro se encontra;
    //Para alterar a cor do Sprite será necessário dividir o valor da cor por 255.0f
    //As cores estão com nome hexadecimal
        if(col.gameObject.tag == "D2D240_Room"){
            sprite_player.color = new Color 
            (210.0f/255.0f,
            210.0f/255.0f,
            64.0f/255.0f);
           
        }

        if(col.gameObject.tag == "5CBA5C_Room"){
            sprite_player.color = new Color 
            (92.0f/255.0f,
            186.0f/255.0f,
            92.0f/255.0f);
            
        }

        if(col.gameObject.tag == "4248C8_Room"){
            sprite_player.color = new Color 
            (66.0f/255.0f,
            72.0f/255.0f,
            200.0f/255.0f);
          
        }

        if(col.gameObject.tag == "A0AB4F_Room"){
            sprite_player.color = new Color
            (160.0f/255.0f,
            171.0f/255.0f,
            79.0f/255.0f);
         
        }

        if(col.gameObject.tag == "C66C3A_Room"){
            sprite_player.color = new Color
            (198.0f/255.0f,
            108.0f/255.0f,
            58.0f/255.0f);
        
        }

        if(col.gameObject.tag == "000000_Room"){
            sprite_player.color = new Color
            (0.0f/255.0f,
            0.0f/255.0f,
            0.0f/255.0f);
        }

        

         if(col.gameObject.tag == "9246C0_Room"){
            sprite_player.color = new Color
            (146.0f/255.0f,
            70.0f/255.0f,
            192.0f/255.0f);
        }
    }
}
