using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //Relacionado ao Jogador
    public GameObject player;
    public Player playerScript;

    //Relacionado ao Bat
    public GameObject bat;

    //teste de função
    public Rigidbody2D rgd2d;
    public GameObject magnet;

    //parte sonora
    public AudioSource audioSource;
    public AudioClip pickUpSound;
    public AudioClip dropSound;

    //contador de item coletado
    //public int itemCount;
    private BoxCollider2D bc2d;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
        playerScript = player.GetComponent<Player>();
        bc2d = GetComponent<BoxCollider2D>();

        //Relacionado ao Bat
        bat = GameObject.Find("Bat");

        //teste
        rgd2d = gameObject.GetComponent<Rigidbody2D>();
        magnet = GameObject.Find("Puller");
    }

    // Update is called once per frame
    void Update()
    {
        DropItem();
        //gameObject.transform.position = itemTransform.transform.position;

    }

    void DropItem()
    {
        if (Input.GetButtonDown("Fire") || Input.GetButtonDown("R")) {
            //gameObject.transform.SetParent(null);
            gameObject.transform.parent = null;
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), magnet.GetComponent<Collider2D>(),false);

            if (playerScript.itemCount >= 1){
                audioSource.PlayOneShot(dropSound, 1);
            }
            bc2d.isTrigger = false;
            playerScript.itemCount = 0;

            
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && playerScript.itemCount == 0){
            gameObject.transform.SetParent(player.transform);
            //fazer o item ignorar a colisão com o "puxador" do ima (ele pega o gameobject do código, o gameobject que se deseja ignorar, insere o valor verdadeiro ou falso)
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(),magnet.GetComponent<Collider2D>(),true);

            audioSource.PlayOneShot(pickUpSound, 1);
            playerScript.itemCount++;
            bc2d.isTrigger = true;
            rgd2d.bodyType = RigidbodyType2D.Kinematic;
        }

        if(col.gameObject.tag == "Bat"){
            gameObject.transform.SetParent(bat.transform);
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), magnet.GetComponent<Collider2D>(), true);
            rgd2d.bodyType = RigidbodyType2D.Kinematic;

        }
    }
}
