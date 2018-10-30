using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlertListing : MonoBehaviour
{
    DateTime now = DateTime.Now;

    public PhotonPlayer PhotonPlayer { get; private set; }
    public TextMeshProUGUI AlertTime;

    [SerializeField]
    private TextMeshProUGUI _alertName;
    private TextMeshProUGUI AlertName
    {
        get { return _alertName; }
    }

    public void ApplyPhotonPlayer(PhotonPlayer photonPlayer)
    {
        AlertName.text = photonPlayer.name;
        string timeNow = now.ToString("HH:mm:ss\\Z");
        AlertTime.text = timeNow;
        Debug.Log(timeNow);
    }
}