using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public GameObject key_castle;
    public GameObject player;
    public GameObject game_manager;

    public bool grabed;

    public GameObject magnet_puller;

    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.Find("GameController");
        key_castle = this.gameObject;
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        magnet_puller = GameObject.Find("Puller");
    }

    // Update is called once per frame\
    void FixedUpdate()
    {                       
        VelocityLimitation();
       
    }

    void VelocityLimitation(){
        //limita a velocidade do rigidbody ao atingir certo valor, usado principalmente com o imã
        if(rb2d.linearVelocity.x > 0.5f || rb2d.linearVelocity.y > 0.5f){
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x/2,rb2d.linearVelocity.y/2);
        }
        if(rb2d.linearVelocity.x < -0.5f || rb2d.linearVelocity.y < -0.5f){
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x/2,rb2d.linearVelocity.y/2);
        }


    }

    void OnTriggerExit2D(Collider2D col){

        // para que quando o item sair do alcance do imã, o item pare de se mexer
        if(col.gameObject.layer == 6){
            rb2d.linearVelocity = new Vector2(0f,0f);
        }
    }
}
