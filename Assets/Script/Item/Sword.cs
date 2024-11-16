using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject sword_item;
    public GameObject player;

    public bool grabed;
    public GameObject magnet_puller;

    public Rigidbody2D rb2d;

     //Relacionado aos sons, audioclip a musica em específico, AudioSource faz o GameObject emitir o som
    public AudioSource soundItem;
    public AudioClip pickupSound;
    public AudioClip dropSound;

    // Start is called before the first frame update
    void Start(){

        sword_item = this.gameObject;
        sword_item.layer = LayerMask.NameToLayer("Default");

        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        magnet_puller = GameObject.Find("Puller");

        soundItem = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate(){

    SwordPosition();
    VelocityLimitation();

    }

    //limitar a velocidade do item ao atingir uma certa velocidade
    void VelocityLimitation(){

        if(rb2d.linearVelocity.x > 0.5f || rb2d.linearVelocity.y > 0.5f){
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x/2, rb2d.linearVelocity.y/2);
        }

        if(rb2d.linearVelocity.x < 0.5f || rb2d.linearVelocity.y < 0.5f){
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x/2, rb2d.linearVelocity.y/2);
        }
    }

    //Fazer com que a espada ao Cavaleiro encostar no item fique com ele
    void SwordPosition(){

    if(grabed == true){

    //Fazer com  que a espada mova junto com o personagem
        sword_item.layer = LayerMask.NameToLayer("Ignore Item");
        rb2d.linearVelocity = new Vector3(0f,0f);

        sword_item.transform.position = new Vector3 
        (player.transform.position.x + 0.5f,
        player.transform.position.y,
        player.transform.position.z);

    }
    else {
        //Deixar o item no lugar ao Cavaleiro pressionar o botão
        sword_item.layer = LayerMask.NameToLayer("Default");
        sword_item.transform.position = sword_item.transform.position;
        
        }

    //botão Fire fará com que o cavaleiro solte o item
    //o botão R mais a função abaixo fara com o que ao Reencarnar o caveleiro o item pernameça no mesmo lugar.
    if(Input.GetButtonDown("Fire")){
        grabed = false;
        soundItem.PlayOneShot(dropSound,1f); 
    }

    if(Input.GetButtonDown("R")){
        grabed = false;
        sword_item.transform.position = sword_item.transform.position;
    }
}

    void OnCollisionEnter2D(Collision2D col){

    if(col.gameObject.tag == "Player"){
    grabed = true;
    soundItem.PlayOneShot(pickupSound,1f); //tocar o som de quando o personagem pega o item
       }

}
    void OnTriggerExit2D (Collider2D col){
        if(col.gameObject.layer == 6){
            rb2d.linearVelocity = new Vector2(0f,0f);
        }
    }


}