using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private PlayerStats player;
    public Text healthText;

    void Awake(){
        player = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    void Update(){
        healthText.text = player.health.ToString();
    }
}
