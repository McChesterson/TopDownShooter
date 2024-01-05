using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV3Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(damage + " : " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
