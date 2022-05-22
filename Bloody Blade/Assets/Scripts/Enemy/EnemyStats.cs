using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHealth;
    [SerializeField, Range(0f, 10000f)] public float speed = 8000f;

    void Awake(){
        enemyHealth = 100;
    }
}
