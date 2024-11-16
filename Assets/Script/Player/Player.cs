using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Informações básicas do Player
    private GameObject player;
    public Rigidbody2D rgb2d;
    public float speedX; //velocidade da movimentação horizontal
    public float speedY; //velocidade da movimentação vertical

    public float initial_posX;
    public float initial_posY;

    public int itemCount;

    void Start(){
        player = this.gameObject;
        rgb2d = GetComponent<Rigidbody2D>();

        initial_posX = player.transform.position.x;
        initial_posY = player.transform.position.y;

    }

    void FixedUpdate(){
        ControlPlayer();
        //rgb2d.velocity = new Vector2(0.0f,0.0f);//deixar a velocidade do rigidibody2d sempre zerado para evitar movimentação sem pressionar 

    }


    //Comandos do Jogador
    void ControlPlayer()
    {
        //Declaração da variavel para receber os inputs
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //Debug.Log("movimentacao X: " + moveX + " e movimentacao y: " + moveY);

        //Movimentação básica direita/esquerda usando eixo X
        if (moveX > 0){
            //rgb2d.velocity = new Vector2(speedX, 0.0f);
           transform.Translate(speedX * Time.deltaTime, 0,0);
        }
        else if (moveX < 0) {
            //rgb2d.velocity = new Vector2(-speedX, 0.0f);
            transform.Translate(-speedX * Time.deltaTime, 0,0);
        }

        //Movimentação básica cima/baixo usando eixo Y

        if (moveY > 0){
            //rgb2d.velocity = new Vector2(0.0f,speedY) ;
            transform.Translate(0, speedY * Time.deltaTime, 0);
        }
        else if (moveY < 0) {
            //rgb2d.velocity = new Vector2(0.0f, -speedY);
            transform.Translate(0,-speedY * Time.deltaTime, 0);
        }


    }

    //para fazer o player passar pelas paredes quando estiver utilizando a ponte
    void OnTriggerEnter2D (Collider2D other){
        if(other.gameObject.layer == 8){
            Physics2D.IgnoreLayerCollision(0,7,true); 
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.layer == 8){
            Physics2D.IgnoreLayerCollision(0,7,false);
        }
    }
}
