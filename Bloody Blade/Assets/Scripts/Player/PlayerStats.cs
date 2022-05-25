using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    private bool invincibilityOnCooldown = false;
    public int ammo;
    public int ammoRefillAmount = 3;
    private int maxAutoAmmoRefill = 10;
    public float AutoAmmoRefillCooldown = 5f;
    void Awake(){
        health = 5;
        ammo = 10;
    }

    void Update(){
        if(AutoAmmoRefillCooldown > 0){
            AutoAmmoRefillCooldown -= Time.deltaTime;
        }
        else{
            StartCoroutine("AutoAmmoRefill");
        }
    }

    IEnumerator AutoAmmoRefill(){
        if(ammo < maxAutoAmmoRefill){
            ammo++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("enemy")){
            if(!invincibilityOnCooldown){
                StartCoroutine("invincibilityCooldown");
                health--;
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
            ammo += ammoRefillAmount;
            Destroy(collider.gameObject);
        }
    }
}
