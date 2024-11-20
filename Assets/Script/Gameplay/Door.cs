using UnityEngine;

//Script com objetivo de fazer com que ao encostar a chave o portão se abra.
public class Door : MonoBehaviour
{
    [SerializeField] private BoxCollider2D bc2d;//variavel para armazenar o rigidbody2D do gameObject
    [SerializeField] private float doorOpening; //valor para a locomoção da porta ao abrir com a chave
    [SerializeField] private GameObject doorCastle; //variavel para armazenar ao GameObject da do portão
    [SerializeField] private string keyName; //string para digitar o nome da chave 
    [SerializeField] private string passageName;
    [SerializeField] private GameObject passageCastle;

    // Start is called before the first frame update
    void Start()
    {
        doorCastle = this.gameObject;
        bc2d = GetComponent<BoxCollider2D>();

        bc2d.enabled = true; //função enabled serve para ativar ou desativar algo do GameObject
        passageCastle = GameObject.Find(passageName);
        passageCastle.SetActive(false);
    }   

    void OnTriggerEnter2D(Collider2D other){
        //é possível usar uma string publica para digitar o nome do GameObject e especificar
        if(other.gameObject.name == keyName){ 

            doorCastle.transform.position = 
            new Vector3(doorCastle.transform.position.x,
            doorCastle.transform.position.y + doorOpening,
            doorCastle.transform.position.z);
            
            bc2d.enabled = false;
            passageCastle.SetActive(true);
        }
    }
}
