using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Objetivo do Script>
/// Fazer com que o cavaleiro ao escostar na ultima sala com o cálice o jogo seja finalizado
///  
/// </summary>
public class Finish : MonoBehaviour
{
    //Fazer com 
    public GameObject wall_finish;
    public Animator anim_wall;

    public GameObject player;
    public Player plScript;

    public BoxCollider2D bc2D;

     //som
    public AudioSource gameSound;
    public AudioClip winSound;

    void Start(){


        player = GameObject.Find("Player");
        wall_finish = GameObject.Find("wall_yellow_finish");
        anim_wall = wall_finish.GetComponent<Animator>();

        plScript = player.GetComponent<Player>();

        bc2D = GetComponent<BoxCollider2D>();
        gameSound = GetComponent<AudioSource>();


    } 

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Cup"){
            bc2D.enabled = false;
            anim_wall.Play("End_Game");
            //Time.timeScale = 0;
            plScript.speedY = 0f;
            plScript.speedX = 0f;

            gameSound.PlayOneShot(winSound, 1f);
            
            Debug.Log("Venceu");

        }
    }

}
