using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para fazer com que o Dragão ataque o cavaleiro
public class DragonAttack : MonoBehaviour
{
    public Animator anim;
    GameObject dragonBody;

    //Informações do Player;
    public GameObject player;
    public LifePlayer lPlayer;


    public GameObject dragonSensorObj;
    public string dragonSensorName;

    //relacionado para o dragão poder atacar quando o player encostar
    public bool can_attack;
    public Rigidbody2D rb2d;
   

    //Colisor do sensor do sensor
    public CircleCollider2D cc2D; //CircleCollider do sensor
    public DragonLife dLife;//relacionado a vida do dragão
    public DragonYellow dYellow; //script principal do dragão
    private float initialSpeed; // velocidade inicial do dragão

    public BoxCollider2D bc2D; //BoxCollider desse gameObject

    // para fazer a contagem até engolir o cavaleiro
    public float timetokillPlayer;
    private float timeInitial;

    private bool startCount;
    private bool waitCount;

    public float waitForChase; //fazer o dragão esperar quando o jogador sair
    public float initialWaitChase;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        dragonBody = this.gameObject;
        dragonSensorObj = GameObject.Find(dragonSensorName);
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();
        dLife = GetComponent<DragonLife>(); //pegar do próprio gameObject
        dYellow = GetComponentInParent<DragonYellow>(); //Pegar o script no gameobject pai
        initialSpeed = dYellow.speed; // velocidade do dragão
        timeInitial = timetokillPlayer; //Tempo para o Dragão engolir o cavaleiro
        cc2D = GetComponentInParent<CircleCollider2D>();
        lPlayer = player.GetComponent<LifePlayer>(); //vida do cavaleiro

        waitCount = false;
    }

    // Update is called once per frame
    void FixedUpdate() {

        AttackPlayer();
        WaitCountAttack();
        
        if(Input.GetButtonDown("R")){
            bc2D.enabled = true;
        }
       
        if (startCount == true) {
            timetokillPlayer -= Time.deltaTime;
        }
        else {
            timetokillPlayer = timeInitial;
        }

        if (timetokillPlayer <= 0) {
            bc2D.enabled = false;
            dragonBody.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
            lPlayer.life = 0;
        }

    }

    //fazer o dragão esperar o jogador sair 
    void WaitCountAttack(){
        if(waitCount == true){
            waitForChase -= Time.deltaTime;
        }
        else{
            waitForChase = initialWaitChase;
        }
    }

    void AttackPlayer(){
        if (can_attack == false && dLife.life > 0) {
            anim.Play("idle");
            dYellow.speed = initialSpeed;
            dragonBody.transform.position =
                new Vector2(dragonSensorObj.transform.position.x,
                dragonSensorObj.transform.position.y);

            startCount = false;
           // dYellow.can_move = true;
            cc2D.enabled = true;
        }

        if (can_attack == true)
        {
            anim.Play("attack");
            startCount = true;
           // dYellow.can_move = false;
        }

    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "Player"  && dLife.life > 0){
            can_attack = true;  
            dragonBody.transform.position = new Vector2(player.transform.position.x + 0.258f,player.transform.position.y - 0.538f);

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
            dYellow.speed = 0f;
            cc2D.enabled = false;
            player.transform.Translate(0.5f * Time.deltaTime,0f,0f);
            Debug.Log("Chamando o Trigger");

        }  

    }

//para quando o cavaleiro sair da colisão do player o dragão
    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.name == "Player") {
            can_attack = false;
            startCount = false;
            waitCount = true;
        }
    }

}
