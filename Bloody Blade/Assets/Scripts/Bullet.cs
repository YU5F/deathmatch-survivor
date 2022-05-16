using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    [SerializeField, Range(10f, 50f)] private float maxRange = 30.0f;

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
    }
}
