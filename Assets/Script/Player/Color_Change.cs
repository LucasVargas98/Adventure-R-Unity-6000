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
    //As cores estão com valor hexadecimal

        if(col.gameObject.tag == "D2D240_Room"){ //Amarelo
            sprite_player.color = new Color 
            (210.0f/255.0f,
            210.0f/255.0f,
            64.0f/255.0f);
           
        }

        else if (col.gameObject.tag == "5CBA5C_Room"){ //Verde 
            sprite_player.color = new Color 
            (92.0f/255.0f,
            186.0f/255.0f,
            92.0f/255.0f);
            
        }

       else if(col.gameObject.tag == "4248C8_Room"){ //Azul
            sprite_player.color = new Color 
            (66.0f/255.0f,
            72.0f/255.0f,
            200.0f/255.0f);
          
        }

         else if(col.gameObject.tag == "A0AB4F_Room"){ //Verde meio amarelado
            sprite_player.color = new Color
            (160.0f/255.0f,
            171.0f/255.0f,
            79.0f/255.0f);
         
        }

        else if(col.gameObject.tag == "C66C3A_Room"){ //Laranja
            sprite_player.color = new Color
            (198.0f/255.0f,
            108.0f/255.0f,
            58.0f/255.0f);
        
        }

        else if(col.gameObject.tag == "000000_Room"){ //Preto
            sprite_player.color = new Color
            (0.0f/255.0f,
            0.0f/255.0f,
            0.0f/255.0f);
        }

        
        else if(col.gameObject.tag == "9246C0_Room"){ //Roxo
            sprite_player.color = new Color
            (146.0f/255.0f,
            70.0f/255.0f,
            192.0f/255.0f);
        }

        
        else if(col.gameObject.tag == "87B754_Room"){ //Verde claro
            sprite_player.color = new Color
            (135.0f/255.0f,
            183.0f/255.0f,
            84.0f/255.0f
            );
        }

        else if(col.gameObject.tag == "B2B2B2_Room"){ //Cinza claro
            sprite_player.color = new Color
            (178.0f/255.0f,
            178.0f/255.0f,
            178.0f/255.0f
            );
        }

        else if (col.gameObject.tag == "FFFFFF_Room")
        { //Branco
            sprite_player.color = new Color
            (255.0f/255.0f,
            255.0f/255.0f,
            255.0f/255.0f);
        }
        
    }
}