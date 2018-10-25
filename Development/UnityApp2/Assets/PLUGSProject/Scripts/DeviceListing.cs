using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeviceListing : MonoBehaviour 
{
    public PhotonPlayer PhotonPlayer { get; private set; }

    [SerializeField]
    private TextMeshProUGUI _deviceName;
    private TextMeshProUGUI DeviceName
    {
        get { return _deviceName; }
    }

    public void ApplyPhotonPlayer(PhotonPlayer photonPlayer)
    {
        DeviceName.text = photonPlayer.name;
    }
}
