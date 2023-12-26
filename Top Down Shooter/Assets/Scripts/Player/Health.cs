using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    //GameObject roomManager;

    public int maxHealth = 100;
    public int currentHealth;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(10);
            Debug.Log("Took 10 damage : Current Health = " + currentHealth);
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //collision.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, 10);
            TakeDamage(10);
            Debug.Log("Took 10 damage : Current Health = " + currentHealth);
        }
    }
    */
    [PunRPC]
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("called Die method");
        RoomManager.instance.SpawnPlayer();
        Destroy(gameObject);
    }
}
