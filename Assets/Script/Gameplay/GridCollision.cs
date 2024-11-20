using UnityEngine;
using UnityEngine.Tilemaps;

//<testar a funcionalidade de colisão do grid em tile especifico>
//Aprender o funcionamento
public class GridCollision : MonoBehaviour
{
    [SerializeField] private Tilemap thisTile;
    [SerializeField] private Grid gridTest;

    void Start(){
        thisTile = GetComponent<Tilemap>();
    }
    void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.tag == "Player"){
            Debug.Log("This actual grid is: ");
        }
    }
}
