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

    //Relacionado aos sons, audioclip a musica em específico, AudioSource faz o GameObject emitir o som
    public AudioSource soundItem;
    public AudioClip pickupSound;
    public AudioClip dropSound;

    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.Find("GameController");
        key_castle = this.gameObject;
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        magnet_puller = GameObject.Find("Puller");

        soundItem = GetComponent<AudioSource>();
    }

    // Update is called once per frame\
    void FixedUpdate()
    {                       
        KeyPosition();
        VelocityLimitation();
       
    }

void VelocityLimitation(){
        //limita a velocidade do rigidbody ao atingir certo valor, usado principalmente com o imã
        if(rb2d.velocity.x > 0.5f || rb2d.velocity.y > 0.5f){
            rb2d.velocity = new Vector2(rb2d.velocity.x/2,rb2d.velocity.y/2);
        }
        if(rb2d.velocity.x < -0.5f || rb2d.velocity.y < -0.5f){
            rb2d.velocity = new Vector2(rb2d.velocity.x/2,rb2d.velocity.y/2);
        }


    }

void KeyPosition(){

   if(grabed == true){

//Fazer com  que a espada mova junto com o personagem
       key_castle.layer = LayerMask.NameToLayer("Ignore Item"); //Renomear o layer do objeto
        rb2d.velocity = new Vector2(0.0f,0.0f); //zera a velocidade do rigidbody

       key_castle.transform.position = new Vector3 
        (player.transform.position.x,
        player.transform.position.y + 0.6f,
        player.transform.position.z); // segue o cavaleiro
    }
    else {
        //Deixar o item no lugar ao Cavaleiro pressionar o botão
        key_castle.layer = LayerMask.NameToLayer("Item");
        key_castle.transform.position = key_castle.transform.position; // posição original do item
    }

    if(Input.GetButtonDown("Fire")){
        grabed = false;
        soundItem.PlayOneShot(dropSound,1f); 
    }

    if(Input.GetButtonDown("R")){
        grabed = false;
        key_castle.transform.position = key_castle.transform.position;
    }

}
    
    void OnCollisionEnter2D(Collision2D col){                   
    if(col.gameObject.tag == "Player"){
     grabed = true;
    soundItem.PlayOneShot(pickupSound,1f); //tocar o som de quando o personagem pega o item
    }

}

    void OnTriggerExit2D(Collider2D col){

        // para que quando o item sair do alcance do imã, o item pare de se mexer
        if(col.gameObject.layer == 6){
            rb2d.velocity = new Vector2(0f,0f);
        }
    }
}
