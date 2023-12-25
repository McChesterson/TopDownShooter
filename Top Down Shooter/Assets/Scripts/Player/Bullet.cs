using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject otherplayer = other.transform.gameObject;
            Debug.Log(otherplayer.GetComponent<PhotonView>().ViewID);
        }

        Destroy(gameObject);
    }
}
