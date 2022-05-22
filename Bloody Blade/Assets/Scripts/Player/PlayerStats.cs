using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    private bool invincibilityOnCooldown = false;
    public int ammo;
    public int refillAmount = 3;
    void Awake(){
        health = 3;
        ammo = 5;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("enemy")){
            if(!invincibilityOnCooldown){
                StartCoroutine("invincibilityCooldown");
                health--;
                Debug.Log("aa");
            }
        }
    }

    IEnumerator invincibilityCooldown(){
        invincibilityOnCooldown = true;
        yield return new WaitForSeconds(2f);
        invincibilityOnCooldown = false;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("ammo")){
            ammo += refillAmount;
            Destroy(collider.gameObject);
        }
    }
}
