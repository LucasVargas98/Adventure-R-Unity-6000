using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragonYellow : MonoBehaviour
{

    //ideia de script é que quando o cavaleiro encostar na colisão do Dragão ele comece a se movimentar até o cavaleiro

    public GameObject dragon;
    public GameObject player;

    //hitbox do Dragão
    public CircleCollider2D dragonSensor;   
    public BoxCollider2D bc2d;
    public GameObject dragonBody;
    public string dragonName;

    //Permissão para o Dragão se mover
    public bool can_move;
    public float speed;

    public int life;

    public GameObject sword;

    //public Animator anim;
    Vector2 dragon_Position;

    public DragonLife dragon_life;

    public DragonAttack scriptDragonAttack;
 
    // Start is called before the first frame update
    void Start()
    {
        dragon = this.gameObject;
        player = GameObject.Find("Player");    
        dragonSensor = GetComponent<CircleCollider2D>();   
        Physics2D.IgnoreLayerCollision(7,10, true);

        dragonBody = GameObject.Find(dragonName);

        dragon_life = dragonBody.GetComponentInChildren<DragonLife>();

        scriptDragonAttack = GetComponentInChildren<DragonAttack>();

    }

    // Update is called once per frame
    void Update()
    {   
        if(dragon_life.life <= 0){
            speed = 0f;
            dragonSensor.enabled = false;
        }

        DragonMove();
    }

    void DragonMove(){
        //função MoveTowards do Vector2 serve para fazer um object seguir outro

        if(can_move == true){
            dragon.transform.position = Vector2.MoveTowards
            (transform.position, player.transform.position, speed * Time.deltaTime);
             
        }
    }

    //Quando o CircleCollider2D do Dragão encostar no cavaleiro vai ativar a booleano para ele seguir o player
    void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.tag == "Player" && dragon_life.life > 0){
            can_move = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player" && dragon_life.life > 0){
            can_move = false;
        }
    }

}
