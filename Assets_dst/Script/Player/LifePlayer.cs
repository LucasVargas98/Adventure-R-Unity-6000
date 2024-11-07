using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ideia do script
//Fazer com o que o cavaleiro ao encostar no Dragão faça ele perder vida;
//vida padrão do cavaleiro é 1

public class LifePlayer : MonoBehaviour
{

    public int life;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        life = 1;
        player = this.gameObject;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Dragon"){
            
        }
    }
}
