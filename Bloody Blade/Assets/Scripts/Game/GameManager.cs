using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerStats player;
    GameObject[] enemies;
    public bool gameOver = false;
    public string gameState;
    
    void Awake(){
        player = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    void Update(){
        enemies = GameObject.FindGameObjectsWithTag("enemy");

        if(player.health <= 0){
            gameOver = true;
            gameState = "Lose";
        }

        if(gameOver){
            for(int i = 0; i < enemies.Length; i++){
                Destroy(enemies[i].gameObject);
            }
        }

        if(gameState == "Lose"){
            SceneManager.LoadScene("LoseScene");
        }
        else if(gameState == "Win"){
            SceneManager.LoadScene("WinScene");
        }
    }
}
