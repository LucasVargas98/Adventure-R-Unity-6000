using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

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

    public string actual_scene;
    public int itemCount;

    //proibir o jogador de reencarnar quando o jogo acaba
    public GameObject finishObj;
    public Finish endGameScript;

    // inicia antes do proprio joho
    void Awake() {
        //Ignorar as físicas de alguns objetos    
        Physics2D.IgnoreLayerCollision(9, 7, true);
        Physics2D.IgnoreLayerCollision(3, 7, true);
        //Physics2D.IgnoreLayerCollision(9, 11, true);
        Physics2D.IgnoreLayerCollision(8, 10, true);

        //pegar dados do script do player
        player = GameObject.Find("Player");
        scriptPlayer = player.GetComponent<Player>();
        scriptLifePlayer = player.GetComponent<LifePlayer>();

        //Salvar as informações iniciais do jogador na Scene
        initialPlayerSpeedX = scriptPlayer.speedX;
        initialPlayerSpeedY = scriptPlayer.speedY;
        initialPlayerPositionX = player.transform.position.x;
        initialPlayerPositionY = player.transform.position.y;

        //pegar as informações do script do Finish.cs
        finishObj = GameObject.Find("FinishGame");
        endGameScript = finishObj.GetComponent<Finish>();
}
    void Update(){
        PlayerFunctions();
        GameController();
    }
        

    //void apenas para funções relacionadas ao jogador
    void PlayerFunctions(){
        if(Input.GetButtonDown("R") && endGameScript.cantR == false){
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
            SceneManager.LoadScene("Levels"); //resetar a Scene atual
        }
    }

}
