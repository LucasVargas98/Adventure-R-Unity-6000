using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para fazer com que o Dragão ataque o cavaleiro
public class DragonAttack : MonoBehaviour
{
    GameObject dragonBody;
    public GameObject player;
    public Animator anim;

    public GameObject dragonSensorObj;

    //relacionado para o dragão poder atacar quando o player encostar
    public bool can_attack;
    public Rigidbody2D rb2d;

    //Colisor do sensor do sensor
    public CircleCollider2D cc2D; 

    public DragonLife dLife;//relacionado a vida do dragão

    public DragonYellow dYellow; //script principal do dragão
    
    private float initialSpeed; // velocidade inicial do dragão

    public BoxCollider2D bc2D;

    // para fazer a contagem até engolir o cavaleiro
    public float timetokillPlayer;
    private float timeInitial;

    private bool startCount;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        dragonBody = this.gameObject;

        dragonSensorObj = GameObject.Find("DragonYellow");

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();

        dLife = GetComponent<DragonLife>(); //pegar do próprio gameObject
        dYellow = GetComponentInParent<DragonYellow>(); //Pegar o script no gameobject pai


        initialSpeed = dYellow.speed; // velocidade do dragão
        timeInitial = timetokillPlayer;

        cc2D = GetComponentInParent<CircleCollider2D>();


    }

    // Update is called once per frame
    void FixedUpdate(){

        if(can_attack == false && dLife.life > 0){
            anim.Play("idle");
            dYellow.speed = initialSpeed;
        }

        if(can_attack == true){
            anim.Play("attack");
            dragonBody.transform.position = new Vector2(player.transform.position.x + 0.258f,player.transform.position.y - 0.538f);
        }

        if(startCount == true){
            timetokillPlayer -= Time.deltaTime;
        }
        else {
            timetokillPlayer = timeInitial;
            
        }

        if(timetokillPlayer <= 0){
            bc2D.enabled = false;
            player.transform.position = new Vector2(dragonBody.transform.position.x, dragonBody.transform.position.y);
            
        }

    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "Player"  && dLife.life > 0){
            can_attack = true;   
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.name == "Player"  && dLife.life > 0){
            can_attack = false;
    }
}

//Para que o cavaleiro encostar na boca do dragão ative a função de ataque
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Player"){
            can_attack = true;
            startCount = true;
            dYellow.can_move = false;
            dYellow.speed = 0f;
            cc2D.enabled = false;
            
        }  
    }

//para quando o cavaleiro sair da colisão do player o dragão
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name == "Player"){
        can_attack = false;
        startCount = false;
        anim.Play("idle");
        dYellow.can_move = true;
        dYellow.speed = initialSpeed;
        cc2D.enabled = true;
        dragonBody.transform.position = new Vector2(0,0);

        }
    }

}
