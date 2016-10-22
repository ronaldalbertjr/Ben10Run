using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject prefab;

    string version = "v1.0";
    string roomName = "Ronald";

    void Update()
    {
        if (!PhotonNetwork.connectedAndReady)
        {
            PhotonNetwork.ConnectUsingSettings(version);
        }
    }

    void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(prefab.name, spawnPoint.position, spawnPoint.rotation, 0);
    }
}
