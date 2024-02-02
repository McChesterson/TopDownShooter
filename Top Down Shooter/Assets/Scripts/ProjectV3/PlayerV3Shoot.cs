using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV3Shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    PlayerV3Movement playerMovemnet;
    [Space]
    public float bulletForce;
    public float fireRate;
    public int playerDamage;

    void Start()
    {
        playerMovemnet = GetComponent<PlayerV3Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(playerMovemnet.isPlayer1 ? KeyCode.Space : KeyCode.Slash))
        {
            Fire();
        }
    }
    public void Fire()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, playerMovemnet.playerDirection);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);

        bullet.GetComponent<BulletV3>().bulletDamage = playerDamage;
    }
}
