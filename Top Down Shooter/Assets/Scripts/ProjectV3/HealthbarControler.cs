using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarControler : MonoBehaviour
{
    public Image healthBar;
    public PlayerV3Health playerHealth;

    public float currentFill;
    void Start()
    {
        currentFill = playerHealth.maxHealth / playerHealth.maxHealth;
        Debug.Log("currentFill started as " + currentFill);
        healthBar.fillAmount = currentFill;
    }
    public void SetFillAmount()
    {
        currentFill = (float)playerHealth.currentHealth / (float)playerHealth.maxHealth;
        //Debug.Log("currentFill = " + currentFill + " as a result of " + playerHealth.currentHealth + " / " + playerHealth.maxHealth);
        healthBar.fillAmount = currentFill;
    }
}