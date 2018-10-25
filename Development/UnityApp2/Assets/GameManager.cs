using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject PlayerInfoText;
    [SerializeField] private GameObject PlayerGrid;

    [SerializeField] private Text PingText;


    private void Update()
    {
        PingText.text = "Network ping: " + PhotonNetwork.GetPing();
    }

    //Called by photon
    public void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        GameObject obj = Instantiate(PlayerInfoText, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(PlayerGrid.transform, false);
        obj.GetComponent<Text>().text = player.name + " Joined the server";
        obj.GetComponent<Text>().color = Color.green;
    }

    public void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        GameObject obj = Instantiate(PlayerInfoText, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(PlayerGrid.transform, false);
        obj.GetComponent<Text>().text = player.name + " left the server";
        obj.GetComponent<Text>().color = Color.red;
    }



}
