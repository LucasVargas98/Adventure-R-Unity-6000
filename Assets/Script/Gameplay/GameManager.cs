using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

/// <Objetivo>
///  Objetivo básico do script é comandar regras simples do jogo
/// armazenar todos os dados iniciais do player
/// </summary>
public class GameManager : MonoBehaviour
{
    //Dados do Cavaleiro/Jogador
    private GameObject player;
    public Player scriptPlayer;
    public LifePlayer scriptLifePlayer;

    //Informações iniciais do jogador quando iniciar o jogo;
    protected float initialPlayerSpeedX;
    protected float initialPlayerSpeedY;
    protected float initialPlayerPositionX;
    protected float initialPlayerPositionY;

    //para o hud de gameplay
    [SerializeField] private GameObject actionButton;

    // <summary>
    /// Referente a informação do menu de pausa
    /// </summary>
    [SerializeField] private GameObject menuPauseUi;
    public GameObject worldMapPanel;
    public GameObject glossaryPanel;

    //proibir o jogador de reencarnar quando o jogo acaba
    public GameObject finishObj;
    public Finish endGameScript;

    // inicia antes do proprio jogo
    void Awake() {
        //Ignorar as físicas de alguns objetos    
        Physics2D.IgnoreLayerCollision(9, 7, true);
        Physics2D.IgnoreLayerCollision(3, 7, true);
        Physics2D.IgnoreLayerCollision(12, 7, true);
        Physics2D.IgnoreLayerCollision(8, 10, true);
        Physics2D.IgnoreLayerCollision(10, 10, true);
        Physics2D.IgnoreLayerCollision(14,9,true); //ima e itens no geral
        Physics2D.IgnoreLayerCollision(12,14,true); //espada e ima

        //pegar dados do script do player
        player = GameObject.Find("Player");
        scriptPlayer = player.GetComponent<Player>();
        scriptLifePlayer = player.GetComponent<LifePlayer>();

        //Salvar as informações iniciais do jogador na Scene
        //Função: Para ser possível reencarnar o player no ponto inicial do mapa
        initialPlayerSpeedX = scriptPlayer.speedX;
        initialPlayerSpeedY = scriptPlayer.speedY;
        initialPlayerPositionX = player.transform.position.x;
        initialPlayerPositionY = player.transform.position.y;

        //pegar as informações do script do Finish.cs
        finishObj = GameObject.Find("FinishGame");
        endGameScript = finishObj.GetComponent<Finish>();
        
        //Encontrar o menu de pausa
        menuPauseUi = GameObject.Find("PauseScreen");

        //pegar o worldMap e o Glossary no gameObject da Scene
        worldMapPanel = GameObject.Find("WorldMap");
        glossaryPanel = GameObject.Find("GlossaryPanel");
        glossaryPanel.SetActive(false);
        menuPauseUi.SetActive(false);

       

        //Encontrar o botão de ação
        actionButton = GameObject.Find("ButtonAction");
        actionButton.SetActive(false);
}
    void Update(){
        PlayerFunctions();
        GameController();
        PauseMenu();    
        GameplayHud();
    }
        

    //void apenas para funções relacionadas ao jogador
    void PlayerFunctions(){

        if(Input.GetButtonDown("R") && endGameScript.cantR == false){
            //if(scriptPlayer.Inventory.Count >= 1){
              //  player.GetComponentInChildren<PickUp>().gameObject.transform.SetParent(null);
           // }
            player.transform.position = new Vector2(initialPlayerPositionX,initialPlayerPositionY);
            scriptLifePlayer.life = 1;
            scriptPlayer.speedX = initialPlayerSpeedX;
            scriptPlayer.speedY = initialPlayerSpeedY;
        }
    }

    void GameController(){
        if(Input.GetButtonDown("Exit")){
            Application.Quit(); //Sair do jogo
        }

        if(Input.GetButtonDown("Restart")){
            SceneManager.LoadScene("MainMenu"); //Voltar para o menu principal
        }

    }

    void GameplayHud(){
        if(scriptPlayer.itemCount == 1){
            actionButton.SetActive(true);
        }
        else{
            actionButton.SetActive(false);
        }
    }

/// <summary>
/// parte do código direcionado apenas ao menu de pausa
/// </summary>


    void PauseMenu(){ //ativar o menu de pausa
        if(Input.GetButtonDown("Pause")){
            menuPauseUi.SetActive(true);
            Time.timeScale = 0;
        }
    }

    //botoes para chamar movimentar pelo menu

    public void Map(){
        glossaryPanel.SetActive(false);
        worldMapPanel.SetActive(true);
    }

    public void Glossary(){
         worldMapPanel.SetActive(false);
         glossaryPanel.SetActive(true);
    }
    public void CloseMenu(){
        menuPauseUi.SetActive(false);
        
        Time.timeScale = 1;
    }

    public void ReturnMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }


}
