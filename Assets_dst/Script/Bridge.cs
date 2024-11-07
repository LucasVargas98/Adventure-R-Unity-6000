using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//qual o objetivo do script?

//fazer com o que player ao encostar na ponte ele pegue o item como qualquer outro;
//utilizar o GameObject Pass com a colisão para fazer o player passar pela parede
//fazendo o que a parede quando o Cavaleiro encostar + a colisão da passagem, o layer da parede seja alterado
//para ignorar a colisão com o jogador

public class Bridge : MonoBehaviour
{

    public GameObject bridge;

    public GameObject pass_bridge; //Gameobject da passagem do player

    public bool grabed;
    public GameObject player;

    public Rigidbody2D rb2d;

    public float item_speedX;
    public float item_speedY;

    // Start is called before the first frame update
    void Start()
    {
     bridge = this.gameObject;
     pass_bridge = GameObject.Find("Pass");
     rb2d = GetComponent<Rigidbody2D>();
     player = GameObject.Find("Player");

    //Physics2D.IgnoreLayerCollision(9,7,true);
    //Physics2D.IgnoreLayerCollision(3,7,true);
    grabed = false;
   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        VelocityLimitation();
        ItemPosition();
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

    void ItemPosition(){

        //através dessa maneira é possível com que o item mova diretamente na posição que o player encostar

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");


        if(grabed == true){

        
        bridge.layer = LayerMask.NameToLayer("Ignore Item");

        //Movimentação básica direita/esquerda usando eixo X
        if(moveX > 0){
            transform.Translate(item_speedX * Time.deltaTime, 0,0);
        }
        else if (moveX < 0) {
            transform.Translate(-item_speedX* Time.deltaTime, 0,0);
        }

        if(moveY > 0){
            transform.Translate(0, item_speedY* Time.deltaTime,0);
        }
        else if (moveY < 0) {
            transform.Translate(0,-item_speedY* Time.deltaTime,0);
        }

        }

        else {
        //Deixar o item no lugar ao Cavaleiro pressionar o botão
    
        bridge.layer = LayerMask.NameToLayer("Item");
        bridge.transform.position = bridge.transform.position; // posição original do item

    }

        //botão Fire fará com que o cavaleiro solte o item
    if(Input.GetButtonDown("Fire")){
        grabed = false;
    }

    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag =="Player"){
            grabed = true;
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag =="Player"){
            grabed = false;
        }
    }
}
