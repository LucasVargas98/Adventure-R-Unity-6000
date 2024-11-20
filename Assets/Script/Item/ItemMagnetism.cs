using UnityEngine;

public class ItemMagnetism : MonoBehaviour
{
    //<Funcionalidade>
    //Esse script vai atuar como o magnetismo do item na qual estiver colocado
    //Ele vai ter uma booleana que vai ser ativada junto ao script PickUp
    //Esse script vai ser colocado no Item Magnet, porém o valor de "distance" constará ZERO 

    [SerializeField] private float speed = 1.5f; //velocidade que desloca-se até o ima
    private float orSpeed; 
    [SerializeField] private float distance;
    [SerializeField] private Transform magnetTransform; //Transform do ima

    public bool canPush; //Essa booleano vai ter integração com o script Pick Up

    void Start(){
        orSpeed = speed;
        canPush = true;
    }

    void Update() {

        distance = Vector2.Distance(transform.position, magnetTransform.position);

        if(canPush == true && distance < 3){
            transform.position = Vector2.MoveTowards(transform.position, magnetTransform.position, speed * Time.deltaTime);
        }

    }
}
