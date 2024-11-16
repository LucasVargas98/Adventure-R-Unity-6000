using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Objetivo do Script>
/// Fazer com que o cavaleiro ao entrar em um lugar seja teletransportado para outro lugar do mapa
/// de acordo com o Vector2
/// </summary>
public class Passage : MonoBehaviour
{
    public Vector2 newPos;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            player.transform.position = new Vector2(newPos.x, newPos.y);
        }
    }
}
