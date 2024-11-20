using UnityEngine;

public class Bridge : MonoBehaviour
{
    //<Funcionamento>
    //Esse script vai ficar no Objeto Pass onde que é um objeto filho do item Brigde
    //Vai pegar informações do script PickUp no objeto pai
    //como tem a informação ItemCount do player dentro do Pickup que limita quantos itens pode possuir
    //ao colidir no colisor passagem de Brigde vai contar como 1 item pego e vai travar o Rigidbody
    //ao passar pela colisão, itemcount vai ficar -- e vai destravar o Rigidbody
    //<>
    
    [SerializeField] private PickUp pickUp;

    [SerializeField] private Rigidbody2D rgd2d;

     [SerializeField] private GameObject parentObj;

    // Start is called before the first frame update
    void Start()
    {
     parentObj = gameObject.GetComponentInParent<GameObject>();
     pickUp = GetComponentInParent<PickUp>();
     rgd2d = GetComponentInParent<Rigidbody2D>();
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag =="Player"){
            //pickUp.playerScript.itemCount++;
           
            parentObj.tag = "CantPickUp"; 
            rgd2d.constraints = RigidbodyConstraints2D.FreezeAll;
  
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag =="Player"){
            //pickUp.playerScript.itemCount--;
            parentObj.tag = "Bridge";
            rgd2d.constraints = RigidbodyConstraints2D.None;
            rgd2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
