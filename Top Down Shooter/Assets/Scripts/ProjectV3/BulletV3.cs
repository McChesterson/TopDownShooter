using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletV3 : MonoBehaviour
{
    [SerializeField]Rigidbody2D rb;
    [SerializeField]CircleCollider2D circleCol;
    public int bulletDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("bulletDamage = " + bulletDamage);
            collision.gameObject.GetComponent<PlayerV3Health>().TakeDamage(bulletDamage);
        }

        Destroy(gameObject);
    }
}
