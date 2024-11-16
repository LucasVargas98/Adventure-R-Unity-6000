using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private GameObject GameSelectionMenu;

    bool canCode;


    void Awake(){
        Player = GameObject.Find("Player");
        Player.SetActive(false);
        GameSelectionMenu = GameObject.Find("GameSelection");
        canCode = true;
    }

    void Update(){

        if(Input.GetButton("Restart") && Input.GetButton("R") && Input.GetButton("Exit") && canCode == true){
            GameSelectionMenu.SetActive(false);
            Player.SetActive(true);
            canCode = false;
        }

        if (Input.GetButton("Fire") && Input.GetButton("R")){
            SceneManager.LoadScene("MainMenu");
        } 
    }

//Funções com o intuito de OnClick para ser possivel escolher qual level o jogador irá escolher
    BaseEventData baseEvent;
    public void Level1(){
        SceneManager.LoadScene("Level1");
    }

    public void Level2(){
        SceneManager.LoadScene("Level2");
    }

    public void Level3(){
        SceneManager.LoadScene("Level3");
    }

    public void Exit(){
        Application.Quit();
    }
}
