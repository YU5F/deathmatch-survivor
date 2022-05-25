using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public float spawnRate = 2f;
    [SerializeField] private float rateIncreseDelay = 30f;
    public float maxSpawnRate = 0.5f;
    [SerializeField] private float delayDecrease = 0.1f;
    private GameObject[] spawnPositions;
    private int spawnPositionAmount;
    private GameManager gameManager;
    private int mainEnemyAmount;

    void Awake(){
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawnPositions = GameObject.FindGameObjectsWithTag("enemySpawnPos");
        spawnPositionAmount = spawnPositions.Length;
    }

    void Start(){
        StartCoroutine(SpawnObject(spawnRate));
    }

    IEnumerator SpawnObject(float firstDelay){
        if(!gameManager.gameOver){
            float spawnRateCountdown = rateIncreseDelay;
            float spawnCountDown = firstDelay;
            while(true){
                yield return null;
                spawnRateCountdown -= Time.deltaTime;
                spawnCountDown -= Time.deltaTime;

                if(spawnCountDown < 0){
                    spawnCountDown += spawnRate;
                    Instantiate(enemy, spawnPositions[randomNumberGenerate(spawnPositionAmount)].transform.position, Quaternion.identity);
                }

                if(spawnRateCountdown < 0 && spawnRate > maxSpawnRate){
                    spawnRateCountdown += rateIncreseDelay;
                    spawnRate -= delayDecrease;
                }
            }
        }
    }

    void Update(){
        mainEnemyAmount = GameObject.FindGameObjectsWithTag("mainEnemies").Length;
        if(mainEnemyAmount == 0){
            gameManager.gameOver = true;
            gameManager.gameState = "Win";
        }
    }

    int randomNumberGenerate(int max){
        return Random.Range(0, max);
    }
}
