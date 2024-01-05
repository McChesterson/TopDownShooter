using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviour
{
    [SerializeField] int bulletDamage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject otherplayer = other.transform.gameObject;
            otherplayer.GetComponent<PlayerV3Health>().TakeDamage(bulletDamage);
            Debug.Log(otherplayer.name + " took (" + bulletDamage + ") damage");

            //other.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, bulletDamage);
            //Debug.Log(other.gameObject.GetComponent<PhotonView>().ViewID + "took " + bulletDamage + " damage");

        }

        Destroy(gameObject);
    }
}
