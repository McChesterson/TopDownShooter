using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] PlayerSetup playerSetup;
    [SerializeField] PlayerMovement playerMovement;
    [Space]
    [SerializeField] float bulletForce;
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<SpriteRenderer>().color = playerSetup.startColor;
        Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();

        bulletrb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
