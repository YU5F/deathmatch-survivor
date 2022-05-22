using UnityEngine;

public class Throwable : MonoBehaviour
{
    private GameObject player;
    [SerializeField, Range(10f, 50f)] private float maxRange = 30.0f;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject drop;

    void Awake(){
        player = GameObject.Find("Player");
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
            Instantiate(drop, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
        }
    }
}
