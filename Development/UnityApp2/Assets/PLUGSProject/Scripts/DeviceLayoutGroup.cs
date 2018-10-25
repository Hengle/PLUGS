using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeviceLayoutGroup : MonoBehaviour
{

    [SerializeField]
    private GameObject _deviceListingPrefab;
    private GameObject DeviceListingPrefab
    {
        get { return _deviceListingPrefab; }
    }

    private List<DeviceListing> _deviceListings = new List<DeviceListing>();
    private List <DeviceListing> DeviceListings
    {
        get { return _deviceListings; }
    }

    private void OnJoinedRoom()
    {
        MainCanvasManager.Instance.HostDashboardCanvas.transform.SetAsLastSibling();

        PhotonPlayer[] photonPlayers = PhotonNetwork.playerList;
        for (int i = 0; i < photonPlayers.Length; i++)
        {
            PlayerJoinedRoom(photonPlayers[i]);
        }
    }


    private void OnMasterClientSwitched(PhotonPlayer newMasterClient)
    {
        PhotonNetwork.LeaveRoom();
    }

    private void OnPhotonPlayerConnected(PhotonPlayer photonPlayer)
    {
        PlayerJoinedRoom(photonPlayer);
    }

    private void OnPhotonPlayersDisconnected(PhotonPlayer photonPlayer)
    {
        PlayerLeftRoom(photonPlayer);
    }

    private void PlayerJoinedRoom(PhotonPlayer photonPlayer)
    {
        if (photonPlayer == null)
                return;

            PlayerLeftRoom(photonPlayer);

            GameObject deviceListingObj = Instantiate(DeviceListingPrefab);
            deviceListingObj.transform.SetParent(transform, false);

            DeviceListing deviceListing = deviceListingObj.GetComponent<DeviceListing>();
            deviceListing.ApplyPhotonPlayer(photonPlayer);

            DeviceListings.Add(deviceListing);

    }

    private void PlayerLeftRoom(PhotonPlayer photonPlayer)
    {
        int index = DeviceListings.FindIndex(x => x.PhotonPlayer == photonPlayer);
        if (index != -1)
        {
            Destroy(DeviceListings[index].gameObject);
            DeviceListings.RemoveAt(index);
        }
    }

    public void OnCLickRoomState()
    {
        if (!PhotonNetwork.isMasterClient)
            return;

        PhotonNetwork.room.IsOpen = !PhotonNetwork.room.IsOpen;
        PhotonNetwork.room.IsVisible = PhotonNetwork.room.IsOpen;
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
}
