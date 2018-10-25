using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnScript : MonoBehaviour {

    public static RespawnScript Instnace;

    [HideInInspector] public GameObject localPlayer;

    public GameObject respawnCanvas;

    public Text timerText;

    [SerializeField] private float timerAmount = 10;

    private bool enableTimer = false;


    private void Awake()
    {
        Instnace = this;
    }

    private void Update()
    {
        if(enableTimer)
        {

            timerAmount -= Time.deltaTime;
            timerText.text = "Respawn in: " + timerAmount.ToString("F0"); 

            if(timerAmount <= 0)
            {
                localPlayer.GetComponent<PhotonView>().RPC("respawnPlayer", PhotonTargets.AllBuffered);
                respawnCanvas.SetActive(false);
                enableTimer = false;
            }

        }
    }

    public void StartTimer()
    {
        timerAmount = 10f;
        respawnCanvas.SetActive(true);
        enableTimer = true;
    }





}
