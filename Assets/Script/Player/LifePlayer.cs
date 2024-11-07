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
    public Player plScript;

    // Start is called before the first frame update
    void Start()
    {
        life = 1;
        player = this.gameObject;
        plScript = GetComponent<Player>();
    }


    // Update is called once per frame
    void Update()
    {
        if(life <= 0){
            plScript.speedY = 0;
            plScript.speedX = 0;
        }
    }
    
}
