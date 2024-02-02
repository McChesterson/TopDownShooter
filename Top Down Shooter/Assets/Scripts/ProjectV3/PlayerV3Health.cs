using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV3Health : MonoBehaviour
{
    public HealthbarControler healthBar;
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(damage + " : " + currentHealth);
        healthBar.SetFillAmount();

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
