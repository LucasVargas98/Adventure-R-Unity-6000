using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script com objetivo de fazer com que ao encostar a chave o portão se abra.
public class Door : MonoBehaviour
{
    public BoxCollider2D bc2d;//variavel para armazenar o rigidbody2D do gameObject
    public float door_opening; //valor para a locomoção da porta ao abrir com a chave
    public GameObject door_castle; //variavel para armazenar ao GameObject da do portão
    public string key_name; //string para digitar o nome da chave 
    public string passageName;
    public GameObject passageCastle;

    // Start is called before the first frame update
    void Start()
    {
        door_castle = this.gameObject;
        bc2d = GetComponent<BoxCollider2D>();

        bc2d.enabled = true; //função enabled serve para ativar ou desativar algo do GameObject
        passageCastle = GameObject.Find(passageName);
        passageCastle.SetActive(false);
    }   

    void OnTriggerEnter2D(Collider2D other){
        //é possível usar uma string publica para digitar o nome do GameObject e especificar
        if(other.gameObject.name == key_name){ 

            door_castle.transform.position = 
            new Vector3(door_castle.transform.position.x,
            door_castle.transform.position.y + door_opening,
            door_castle.transform.position.z);
            
            bc2d.enabled = false;
            passageCastle.SetActive(true);

            Debug.Log("Passando");
        }
    }
}
