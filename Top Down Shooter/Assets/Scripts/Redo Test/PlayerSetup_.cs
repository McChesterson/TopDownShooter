using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup_ : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject playerCam;

    public void SetUp()
    {
        playerMovement.enabled = true;
        playerCam.SetActive(true);
    }
}
