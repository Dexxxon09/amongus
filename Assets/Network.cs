using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class Network : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    public Text statusText;
    public CameraMove playerCamera;
    void Start()
    {
        statusText.text = "Connecting";
        PhotonNetwork.NickName = "Player" + Random.RandomRange(0, 5000);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        statusText.text = "Connected to Master";
        PhotonNetwork.JoinOrCreateRoom("Room" + Random.RandomRange(0, 5000), new RoomOptions() { MaxPlayers = 4 }, null);
    }
    public override void OnJoinedRoom()
    {
        statusText.text = "Connected";
        PhotonNetwork.Instantiate("Player", new Vector3(Random.Range(21, 0), -30, Random.Range(-45, 12)), Quaternion.identity);
    }
}
