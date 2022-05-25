using UnityEngine;

public class SpawnPositions : MonoBehaviour
{
    public int health;
    private float rateDecreaseRate = 0.3f;
    private SpawnEnemy spawner;

    void Awake(){
        health = 5;
        spawner = GameObject.Find("Spawn Manager").GetComponent<SpawnEnemy>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("bullet")){
            health--;
            if(health == 0){
                Destroy(gameObject);
                if(spawner.spawnRate >= spawner.maxSpawnRate){
                    spawner.spawnRate -= rateDecreaseRate;
                }
            }
        }
    }
}
