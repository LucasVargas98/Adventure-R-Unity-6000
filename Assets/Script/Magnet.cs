using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    //informações do ima
    public GameObject magnet;
    public float pullerSpeed;

    //informações do player
    public GameObject player;
    public Player scriptPlayer;

    public bool canMove;

    //teste de função
    public Rigidbody2D rgd2d;

    void Start(){
        magnet = GameObject.Find("MagnetPoint");
        canMove = false;

        //teste
        rgd2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {

        if (canMove == true){
            rgd2d.isKinematic = false;
            gameObject.transform.position = Vector2.MoveTowards(transform.position, magnet.transform.position, pullerSpeed * Time.deltaTime);
        }
        else if (canMove == false) {
            rgd2d.isKinematic = true;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Magnet" && gameObject.transform.parent == null)
        {
           canMove = true; 
        }
        
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Magnet")
        {
            canMove = false;
        }
    }
}