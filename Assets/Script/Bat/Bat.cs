using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public GameObject bat;


    //talvez um case com valor int de possíveis locais onde ele irá
   public int movBat;

   //movimentação do morcego     
   public float speedX;
   public float speedY;

    //float para fazer com que o morcego mude de direção     
    public float timeChange;
    private float changeCount;

    //teste com o player principal
    public GameObject player;
    public BoxCollider2D bc2d;

    //booleana para determinar se o morcego pode andar ou ser pego pelo Player
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {   
        //setar as informações iniciais do morcego
        bat = GameObject.Find("Bat");
        movBat = Random.Range(0, 3);
        changeCount = timeChange;
        player = GameObject.Find("Player");
        canMove = true;
        bc2d = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canMove == true){
            Moviment();
        }
        else
        {
            PlayerPickUp();
        }

        if (Input.GetButtonDown("Fire")){
            gameObject.transform.SetParent(null);
            canMove = true;
        }

    }

    void Moviment()
    {
        switch(movBat){
            case 0:
            //   bat.transform.position = new Vector2(player.transform.position.x  - 10, player.transform.position.y + Random.Range(-6,6));
                speedX = -4;
                speedY = 0;
                break;

            case 1:
              // bat.transform.position = new Vector2(player.transform.position.x + Random.Range(-6, 6), player.transform.position.y + 10);
                speedX = 0;
                speedY = 4;
                break;

            case 2:
               // bat.transform.position = new Vector2(player.transform.position.x - 10, player.transform.position.y - 10);
                speedX = -4;
                speedY = -4;
                break;

            case 3:
             //  bat.transform.position = new Vector2(player.transform.position.x + 10, player.transform.position.y + 10);
                speedX = 4;
                speedY = 4;
                break;

            case 4:
                //bat.transform.position = new Vector2(player.transform.position.x + 10, player.transform.position.y + Random.Range(-6,6));
                speedX = 4;
                speedY = 0;
                break;

            case 5:
               // bat.transform.position = new Vector2(player.transform.position.x + Random.Range(-6, 6), player.transform.position.y - 10);
                speedX = 0;
                speedY = -4;
                break;

            case 6:
               // bat.transform.position = new Vector2(player.transform.position.x + Random.Range(-6, 6), player.transform.position.y + 10);
                speedX = 0;
                speedY = 4;
                break;

        }

        bc2d.isTrigger = false;
        bat.transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime,0);

        timeChange -= Time.deltaTime;

        if (timeChange <= 0){
            movBat = Random.Range(0, 7);
            timeChange = changeCount;
            bat.transform.position = new Vector2(player.transform.position.x + Random.Range(-6, 6), player.transform.position.y + Random.Range(-4, 4));
        }
    }

    void PlayerPickUp(){
        transform.SetParent(player.transform);
        bc2d.isTrigger = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canMove = false;    
        }
    }
}
