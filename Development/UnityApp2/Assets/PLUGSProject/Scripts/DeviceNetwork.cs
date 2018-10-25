using UnityEngine;
using System.Collections;

public class DeviceNetwork : MonoBehaviour {

    public static DeviceNetwork Instance;
    public string DeviceName { get; set; }
    private ExitGames.Client.Photon.Hashtable m_playerCustomProperties = new ExitGames.Client.Photon.Hashtable();
	// Use this for initialization
	void Awake () 
    {
        Instance = this;

        DeviceName = "Device#" + Random.Range(1000, 9999);

        PhotonNetwork.sendRate = 60;
       // PhotonNetwork.SendRateOnSerialize = 30;
	}
	
    [PunRPC]

    private IEnumerator C_SetPing()
    {
        while (PhotonNetwork.connected)
        {
            m_playerCustomProperties["Ping"] = PhotonNetwork.GetPing();

            yield return new WaitForSeconds(0.5f);
        }

        yield break;
    }

    private IEnumerator C_ShowPing()
    {
        while (PhotonNetwork.connected)
        {
//            int ping = (int)PhotonPlayer.CustomProperties["Ping"];
//            Debug.Log("ping = " + ping);

            yield return new WaitForSeconds(0.5f);
        }
        yield break;
    }

    private void OnConnectedToMaster()
    {
        StartCoroutine(C_SetPing());
        StartCoroutine(C_ShowPing());
    }

}
