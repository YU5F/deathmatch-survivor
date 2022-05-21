using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    [SerializeField, Range(10f, 50f)] private float maxRange = 30.0f;
    [SerializeField, Range(1, 100)] private int damage = 10;
    [SerializeField] private GameObject enemy;
    private EnemyStats enemyStats;

    void Awake(){
        player = GameObject.Find("Player");
        enemyStats = enemy.GetComponent<EnemyStats>();
    }
    void Update(){
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance > maxRange){
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(!collision.gameObject.CompareTag("player")){
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("enemy")){
            enemyStats.enemyHealth -= damage;
            if(enemyStats.enemyHealth <= 0){
                Destroy(collision.gameObject);
                enemyStats.enemyHealth = 100;
            }
        }
    }
}
