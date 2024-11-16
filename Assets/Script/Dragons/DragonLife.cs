using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fazer com o que o dragão ao encostar na espada morra
/// </summary>
public class DragonLife : MonoBehaviour{

    //informações principais do dragão
     public int life;
     public Animator anim;
     public BoxCollider2D bc2d;
     public Rigidbody2D rb2d;

 //Som
    public AudioSource dragonSound;
    public AudioClip deadSound;


    void Start(){
        anim = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        dragonSound = GetComponent<AudioSource>();
    }

    void FixedUpdate(){
        Death();
    }

    //Aciona a animação de morte do Dagrão
    void Death(){
        if(life <= 0){
            anim.Play("death");
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Sword"){
            life --;
            dragonSound.PlayOneShot(deadSound, 1f);
           
        }
    }

    void OnTriggerEnter2D(Collider2D other){
         if(other.gameObject.tag == "Sword"){
            life --;
            dragonSound.PlayOneShot(deadSound, 1f);
         
        }
    }
}
