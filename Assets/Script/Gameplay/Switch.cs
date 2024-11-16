
using UnityEngine;

public class Switch : MonoBehaviour
{
    //Script simples, apenas ativar um objeto quando o Player encostar no objeto o qual esse script está atrelado
    [SerializeField] private GameObject objectActive;
    [SerializeField] private SpriteRenderer spriteSwitch;

    
    
    void Awake(){
        objectActive.SetActive(false);
        spriteSwitch = GetComponent<SpriteRenderer>();
        spriteSwitch.color = new Color
            (198.0f/255.0f,
            108.0f/255.0f,
            58.0f/255.0f);

    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            objectActive.SetActive(true);
            spriteSwitch.color = new Color
            (66.0f/255.0f,
            72.0f/255.0f,
            200.0f/255.0f);

            Debug.Log("Trigger");
        }
    }
}
