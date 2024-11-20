using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Informações básicas do Player
    private GameObject player;
    private Rigidbody2D rgb2d;
    [SerializeField] public float speedX; //velocidade da movimentação horizontal
    [SerializeField] public float speedY; //velocidade da movimentação vertical

    private float initial_posX;
    private float initial_posY;

    //Inventário do player usando listas
    [SerializeField] public List<GameObject> Inventory = new List<GameObject>(); 

    [SerializeField] private GameObject darkenessMaze;
    public int itemCount;

    void Start(){
        player = this.gameObject;
        rgb2d = GetComponent<Rigidbody2D>();

        initial_posX = player.transform.position.x;
        initial_posY = player.transform.position.y;

        //darkenessMaze = GameObject.Find("darkness");

    }

    void Update(){
        ControlPlayer();
    }


    //Comandos do Jogador
    private void ControlPlayer(){
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
        
        //trabalha em conjunto com script PickUp colocado nos itens do jogo

        if(Inventory.Count >= 1){
            if (Input.GetButtonDown("Fire") && Time.timeScale > 0 || Input.GetButtonDown("R") && Time.timeScale > 0) {
               gameObject.GetComponentInChildren<PickUp>().RemoveItemInventory();
            }
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {   

        if (col.gameObject.tag == "Item" && Inventory.Count > 1 
        || col.gameObject.tag == "Magnet"  && Inventory.Count > 1 
        || col.gameObject.tag == "Sword" && Inventory.Count > 1
        || col.gameObject.tag == "Brigde" && Inventory.Count > 1){

           gameObject.GetComponentInChildren<PickUp>().RemoveItemInventory();
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
