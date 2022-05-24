using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerStats player;
    GameObject[] enemies;
    public bool gameOver = false;
    
    void Awake(){
        player = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    void Update(){
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        if(player.health <= 0){
            gameOver = true;
            for(int i = 0; i < enemies.Length; i++){
                Destroy(enemies[i].gameObject);
            }
        }
    }
}
