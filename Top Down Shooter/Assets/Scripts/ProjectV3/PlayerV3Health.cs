using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerV3Health : MonoBehaviour
{
    public ParticleSystem deathParticle;
    public GameObject deathPartPos;

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
        deathPartPos.transform.position = transform.position;
        deathParticle.Play();
        Debug.Log("played death effect");
    }
}
