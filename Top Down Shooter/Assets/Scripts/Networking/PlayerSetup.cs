using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    public Color startColor;

    public void SetLocalPlayer()
    {
        playerMovement.enabled = true;

        startColor = Random.ColorHSV();
        GetComponent<SpriteRenderer>().color = startColor;
    }
}
