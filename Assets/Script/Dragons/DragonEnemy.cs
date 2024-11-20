using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class DragonEnemy : MonoBehaviour
{
    //<Função 1>
    //Utilizando Vector2.Distance para calcular a distancia entre o player e o dragão para ele perseguir

    //<Função 2>
    //Utilizando Vector2.Distance para calcular a distancia entre a espada e o dragão para ele fugir

    //<State machine usando Enum>
    //Criada para melhor separar as funções de IA do dragão
    public enum dragonAi{
        idle, //dragão parado
        guarding, //guardar itens
        run, //correndo atrás do player
        attack, //atacando o player
        kill, //quando engole o player
        scape, //fugir ao estar próximo a espada
        death, //morrer ao encostar na espada

    }

    public dragonAi dragonStatus;

    //informações do player
    [SerializeField] private float playerDistance; //Float para calcular a distancia do player
    [SerializeField] private Transform playerTransform; //posição do player dentro da scene

    [SerializeField] private float maxDistance; //distancia maxima que pode ficar entre o player e o dragão

    [SerializeField] private GameObject player; //GameObject do Player
    [SerializeField] private LifePlayer playerScript; //pegar o script do Player

    //informações da espada
    [SerializeField] private float swordDistance;
    [SerializeField] private Transform swordTransform;

    //Aparentemente o dragão não foge da espada
    //Bool para ativar/desativar manualmente maquina de estado Scape
    [SerializeField] private bool canScape;

    //Informações do dragão
    //Rigidbody, box collider estão no GameObject pai
    //Sprite Renderer, Animator e Audio no GameObject filho
    private Rigidbody2D rg2d; //Rigidbody2D do dragão 
    private Animator anim; //animador do GameObject filho

    //criar um contador
    [SerializeField] private float counter;
    [SerializeField] private float maxCounter;
    [SerializeField] public float speed; //velocidade de movimento do dragão
    private float speedOr; //variavel para armazenar a velocidade original do dragão

    //vida do dragão
    public int life = 1;
    [SerializeField]private bool damage = false;

    //efeitos sonoros
    private AudioSource dragonSounds; //Está no objeto filho
    [SerializeField] private AudioClip slayClip; //som de quando o dragão morre   
    [SerializeField] private AudioClip chompClip; //som de quando ele ataca o player
    [SerializeField] private AudioClip deathClip; //dom de quando engole o player


 
    // Start is called before the first frame update
    void Start()
    {   
        Physics2D.IgnoreLayerCollision(7,10, true); //Ignorar a colisão com as paredes
        Physics2D.IgnoreLayerCollision(11,10, true); //Ignorar colisão com a porta do castelo
        Physics2D.IgnoreLayerCollision(9,10, true); //Ignorar colisão com outros itens exceto espada (Espada está com o layer sword)

        dragonStatus = dragonAi.idle;
        playerTransform = GameObject.Find("Player").transform;
        swordTransform = GameObject.Find("Sword").transform;

        speedOr = speed; //guardar a velocidade original do Dragão
        
        //pegar as informações diretamente por script sem precisar colocar manualmente pelo editor
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponentInChildren<Animator>();
        dragonSounds = gameObject.GetComponent<AudioSource>();
        
        //Pegar as informações do player com objetivo de parar ele quando o dragão engolir
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<LifePlayer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        //Vector Distance calcula a distancia entre um objeto e outro
        playerDistance = Vector2.Distance(transform.position, playerTransform.position); //cacula a distancia entre o player e o gameObjeto
        swordDistance = Vector2.Distance(transform.position, swordTransform.position); //cacula a distancia entre a espada e o gameObjeto
        DragonMove();

    }


    void DragonMove(){

        //<Enum use>
        //Setando as configurações do dragão
        //<>
        switch (dragonStatus){

            case dragonAi.idle:

                anim.Play("idle");
                rg2d.constraints = RigidbodyConstraints2D.None;
                rg2d.constraints = RigidbodyConstraints2D.FreezeRotation;
                counter = 0f;
                speed = speedOr;

                //if(playerDistance < maxDistance && swordDistance > 4){
                    //dragonStatus = dragonAi.run;  
                //}

                if(playerDistance < maxDistance){
                    dragonStatus = dragonAi.run;  
                }


            break;

            case dragonAi.guarding:
            break;

            case dragonAi.run:
                //função MoveTowards do Vector2 serve para fazer um object seguir outro
                transform.position = Vector2.MoveTowards
                (transform.position, playerTransform.position, speed * Time.deltaTime);

                if(swordDistance < 4 && canScape == true){
                    dragonStatus = dragonAi.scape;
                }

                else if(playerDistance < 1){
                    gameObject.transform.SetParent(playerTransform,true); //SetParent usado como uma forma para deixar o dragão como filho do player para pegar a posição local
                    transform.localPosition = new Vector2(0.23f, -0.544f);
                    dragonStatus = dragonAi.attack;
                    dragonSounds.PlayOneShot(chompClip,1f);
                }

               else if(playerDistance > maxDistance){
                    dragonStatus = dragonAi.idle;
                }

            break;

            
            case dragonAi.attack:
                gameObject.transform.SetParent(null); //fazer o GameObject dragão deixar ser filho do GameObject Player
                counter += Time.deltaTime;
                anim.Play("attack");
                speed = 0;
                rg2d.constraints = RigidbodyConstraints2D.FreezeAll;

                if(counter >= maxCounter && playerDistance < 1f){
                    dragonStatus = dragonAi.kill;
                    transform.position = new Vector2(playerTransform.position.x,playerTransform.position.y);
                    dragonSounds.PlayOneShot(deathClip,1f);
                    
                }
                else if(counter >= maxCounter) { 
                    dragonStatus = dragonAi.idle;
                 }

            break;

            case dragonAi.kill:
                counter = 0.0f;
                anim.Play("idle");
                
                playerScript.life = 0;
                speed = 0;

                if(Input.GetButtonDown("R")){
                    dragonStatus = dragonAi.idle;
                }
            break;


            case dragonAi.scape:
                transform.position = Vector2.MoveTowards
                (transform.position, swordTransform.position * -1, speed * Time.deltaTime);

                if(swordDistance > 10){
                    dragonStatus = dragonAi.idle;
                }

                if(playerDistance < 1f){
                    dragonStatus = dragonAi.attack;
                    dragonSounds.PlayOneShot(chompClip,1f);
                }

            break;
            
            case dragonAi.death:
                gameObject.transform.SetParent(null);
                speed = 0f;
                damage = false;
                anim.Play("death");
                rg2d.constraints = RigidbodyConstraints2D.FreezeAll;
            break;


            default:
                dragonStatus = dragonAi.idle;
            return;

        }

        if(damage == true){
            life--;
            if(life <= 0){
                dragonStatus = dragonAi.death;
                dragonSounds.PlayOneShot(slayClip,1f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Sword" && life > 0){
            damage = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Sword" && life > 0){
            damage = true;
        }
    }

}
