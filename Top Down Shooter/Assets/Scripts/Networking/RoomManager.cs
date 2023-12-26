using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager instance;
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Debug.Log("Connecting");

        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log("Connected to server");

        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        Debug.Log("We're in the lobbdy");

        PhotonNetwork.JoinOrCreateRoom("test", null, null);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("We're connected and in a room!");

        SpawnPlayer();

    }
    public void SpawnPlayer()
    {
        var spawnPoint = new Vector3(Random.Range(-8f, 8f), Random.Range(-5f, 5f), 0);
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint, Quaternion.identity);

        _player.GetComponent<PlayerSetup>().SetLocalPlayer();

        _player.GetComponent<Health>().isLocalPlayer = true;
    }
}
