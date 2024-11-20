using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //<Funcionalidade>
    //Ao jogador encostar no item ele, esse GameObject vai ficar Child até ser precionado o botão para soltar

    //Relacionado ao Jogador
    public GameObject player;
    public Player playerScript;

    //Relacionado ao Bat
    public GameObject bat;

    //Pegar a Boolean de ItemMagnetism
    private ItemMagnetism itemMagnetism;

    public GameObject magnet;

    //parte sonora
    public AudioSource audioSource;
    public AudioClip pickUpSound;
    public AudioClip dropSound;


    public Rigidbody2D rgd2d; //
    private BoxCollider2D bc2d; //fazer o item ficar Kinematc para ao encostar nos portões ela abra

    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

        bc2d = GetComponent<BoxCollider2D>();
        rgd2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player"); //Encontrando o player dentro da scene
        playerScript = player.GetComponent<Player>(); //Script player atrelado ao jogador
    
        itemMagnetism = gameObject.GetComponent<ItemMagnetism>();

        //Relacionado ao Bat
        bat = GameObject.Find("Bat");

    }

    private void AddItemInventory(){

        itemMagnetism.canPush = false;
        playerScript.Inventory.Add(this.gameObject); //adicionar o item no inventário do player
        gameObject.transform.SetParent(player.transform);
        audioSource.PlayOneShot(pickUpSound, 1);
        bc2d.isTrigger = true;
        rgd2d.bodyType = RigidbodyType2D.Kinematic;
    }

    public void RemoveItemInventory(){

        gameObject.transform.parent = null;
        gameObject.transform.SetParent(null);

        itemMagnetism.canPush = true;

        if(playerScript.Inventory.Count == 1){
            audioSource.PlayOneShot(dropSound, 1);
        }

        //O inventario do player pode apenas possuir 1 item por vez
         if(playerScript.Inventory.Count >= 1){
            playerScript.Inventory.RemoveAt(0); //remove o item na primeira posição da lista
        }

        rgd2d.bodyType = RigidbodyType2D.Dynamic;
        bc2d.isTrigger = false;

    }

    void OnCollisionEnter2D(Collision2D col)
    {   

        if (col.gameObject.tag == "Player"){
            AddItemInventory();
        }

        if(col.gameObject.tag == "Bat"){
            gameObject.transform.SetParent(bat.transform);
            rgd2d.bodyType = RigidbodyType2D.Kinematic;

        }

    }
}
