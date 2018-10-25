using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plHelathBar : Photon.MonoBehaviour {

	public plMove playerMove;

    public GameObject WorldSpace_Canvas;

	public GameObject localPlayer_Canvas;
	public GameObject OtherPlayer_Canavs;

	public Image localPlayer_HelathBar;
	public Image OtherPlayer_HealathBar;

	public Vector3 localPlayerName_POS;
	public Vector3 OtherPlayerName_POS;


	void Awake()
	{
		if (!playerMove.devTesting) {
			setCorrectCanvas ();
		}

        if(photonView.isMine)
        {
            RespawnScript.Instnace.localPlayer = this.gameObject;
        }

	}


	void setCorrectCanvas()
	{
		if (photonView.isMine) {
			playerMove.playerName.GetComponent<RectTransform> ().anchoredPosition = (localPlayerName_POS);

			localPlayer_Canvas.SetActive (true);
		} else {
			playerMove.playerName.GetComponent<RectTransform> ().anchoredPosition = (OtherPlayerName_POS);

			OtherPlayer_Canavs.SetActive (true);
		}
	}


	[PunRPC]
	public void reduceHelath()
	{
		reduceHealthAmount (0.2f);
	}

    [PunRPC]
    private void deadRespawn()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Rigidbody2D>().simulated = false;
        this.GetComponent<BoxCollider2D>().enabled = false;

        if(!photonView.isMine)
        {
            OtherPlayer_Canavs.SetActive(false);
        }

        WorldSpace_Canvas.SetActive(false);
    }


    [PunRPC]
    private void respawnPlayer()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<Rigidbody2D>().simulated = true;
        this.GetComponent<BoxCollider2D>().enabled = true;

        if (!photonView.isMine)
        {
            OtherPlayer_Canavs.SetActive(true);
            OtherPlayer_HealathBar.fillAmount = 1;
        }
        else
        {
            playerMove.disableMove = false;
            localPlayer_HelathBar.fillAmount = 1;
        }

        WorldSpace_Canvas.SetActive(true);
    }


    private void checkHelathAmount()
    {
        if(localPlayer_HelathBar.fillAmount <= 0.1f)
        {
            RespawnScript.Instnace.StartTimer();
            playerMove.disableMove = true;
            this.GetComponent<PhotonView>().RPC("deadRespawn", PhotonTargets.AllBuffered);
        }
    }


    public void reduceHealthAmount(float hit)
	{
		if (photonView.isMine) {
			localPlayer_HelathBar.fillAmount -= hit;
            checkHelathAmount();
        } else {
			OtherPlayer_HealathBar.fillAmount -= hit;
		}
	}

}
