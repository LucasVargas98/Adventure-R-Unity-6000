using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject magnet;
    public GameObject player;

    public bool grabed;

    public GameObject puller; 

    public float item_speedX;
    public float item_speedY;

    public Rigidbody2D rb2D;


    //Relacionado aos sons, audioclip a musica em específico, AudioSource faz o GameObject emitir o som
    public AudioSource soundItem;
    public AudioClip pickupSound;
    public AudioClip dropSound;

    // Start is called before the first frame update
    void Start(){
        magnet = this.gameObject;
        player = GameObject.FindWithTag("Player");

        puller = GameObject.Find("Puller");
        rb2D = GetComponent<Rigidbody2D>();

        soundItem = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        MagnetPosition();
        //ignorar a colisão do cavaleiro para ele não ser puxado
        Physics2D.IgnoreCollision(puller.GetComponent<CircleCollider2D>(), player.GetComponent<BoxCollider2D>());
    }

    void MagnetPosition(){

    if(grabed == true){

    //Fazer com  que o imã mova junto com o personagem

       magnet.transform.position = new Vector3 
        (player.transform.position.x,
        player.transform.position.y - 0.6f,
        player.transform.position.z); // segue o cavaleiro

        }

    else {
        //Deixar o item no lugar ao Cavaleiro pressionar o botão
        magnet.transform.position = magnet.transform.position;
    
        }

    //botão Fire fará com que o cavaleiro solte o item
    //o botão R mais a função abaixo fara com o que ao Reencarnar o caveleiro o item pernameça no mesmo lugar.
    if(Input.GetButtonDown("Fire")){
        grabed = false;
        soundItem.PlayOneShot(dropSound,1f); 
    }

    if(Input.GetButtonDown("R")){
        grabed = false;
        magnet.transform.position = magnet.transform.position;
    }
}

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            grabed = true;
            soundItem.PlayOneShot(pickupSound,1f); //tocar o som de quando o personagem pega o item
        }
    }

}
