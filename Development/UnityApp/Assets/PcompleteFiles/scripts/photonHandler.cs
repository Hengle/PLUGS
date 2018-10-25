using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class photonHandler : MonoBehaviour {


	public photonButtons photonB;

	public GameObject mainPlayer;

	private void Awake(){
		DontDestroyOnLoad (this.transform);

		PhotonNetwork.sendRate = 30;
		PhotonNetwork.sendRateOnSerialize = 20;

		SceneManager.sceneLoaded += OnSceneFinishedLoading;
	}



	public void createNewRoom(){
		PhotonNetwork.CreateRoom (photonB.createRoomInput.text, new RoomOptions () { MaxPlayers = 6 }, null);
	}


	public void joinOrCreateRoom(){
		RoomOptions roomOptions = new RoomOptions ();
		roomOptions.MaxPlayers = 6;
		PhotonNetwork.JoinOrCreateRoom (photonB.joinRoomInput.text, roomOptions, TypedLobby.Default);
	}


	public void moveScene(){
		photonB = null;

		PhotonNetwork.LoadLevel ("MainGame");
	}


	private void OnJoinedRoom(){
		moveScene ();
		Debug.Log ("We are connected to the room!");
	}


	private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode){
		if(scene.name == "MainGame"){
			spawnPlayer ();		
		}
	}


	private void spawnPlayer(){
        
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        if(PhotonNetwork.playerList.Length == 1)
        {
            PhotonNetwork.Instantiate(mainPlayer.name, spawnPoints[0].transform.position, mainPlayer.transform.rotation, 0);
        }

        if (PhotonNetwork.playerList.Length == 2)
        {
            PhotonNetwork.Instantiate(mainPlayer.name, spawnPoints[1].transform.position, mainPlayer.transform.rotation, 0);
        }

        if (PhotonNetwork.playerList.Length == 3)
        {
            PhotonNetwork.Instantiate(mainPlayer.name, spawnPoints[2].transform.position, mainPlayer.transform.rotation, 0);
        }

        if (PhotonNetwork.playerList.Length == 4)
        {
            PhotonNetwork.Instantiate(mainPlayer.name, spawnPoints[3].transform.position, mainPlayer.transform.rotation, 0);
        }

        if (PhotonNetwork.playerList.Length == 5)
        {
            PhotonNetwork.Instantiate(mainPlayer.name, spawnPoints[4].transform.position, mainPlayer.transform.rotation, 0);
        }

        if (PhotonNetwork.playerList.Length == 6)
        {
            PhotonNetwork.Instantiate(mainPlayer.name, spawnPoints[5].transform.position, mainPlayer.transform.rotation, 0);
        }


    }



}
