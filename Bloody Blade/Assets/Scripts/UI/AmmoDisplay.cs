using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    private PlayerStats player;
    public Text ammoText;

    void Awake(){
        player = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    void Update(){
        ammoText.text = player.ammo.ToString();
    }
}