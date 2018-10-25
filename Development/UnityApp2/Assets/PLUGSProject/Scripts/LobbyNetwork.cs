using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyNetwork : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        print("Connecting to Server...");
        PhotonNetwork.ConnectUsingSettings("0,0,0");
	}
	
    private void OnConnectedToMaster()
    {
        print("Connected to Master");
        PhotonNetwork.playerName = DeviceNetwork.Instance.DeviceName;

        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }
    

    private void OnJoinedLobby()
    {
        print("Joined Lobby");

        if (!PhotonNetwork.inRoom)
            MainCanvasManager.Instance.HostDashboardCanvas.transform.SetAsLastSibling();
    }

}
