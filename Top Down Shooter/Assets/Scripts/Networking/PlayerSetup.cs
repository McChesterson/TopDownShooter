using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Shooting shooting;
    public Color startColor;

    public void SetLocalPlayer()
    {
        playerMovement.enabled = true;
        shooting.enabled = true;
        Debug.Log("SetLocalPlayer");
        startColor = Random.ColorHSV();
        GetComponent<SpriteRenderer>().color = startColor;
    }
}
