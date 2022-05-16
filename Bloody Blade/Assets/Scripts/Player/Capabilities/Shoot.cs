using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private inputController input = null;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField, Range(0f, 50f)] private float bulletForce = 20.0f;

    // Update is called once per frame
    void Update()
    {
        if(input.retrieveFireInput()){
            Shooting();
        }
    }

    void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
