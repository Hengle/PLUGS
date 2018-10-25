using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plHealthBar : Photon.MonoBehaviour {


    public plMove playerMove;

    public GameObject localPlayer_Canvas;
    public GameObject OtherPlayer_Canvas;

    public ImagePosition localPlayer_Healthbar;
    public ImagePosition OtherPlayer_Healthbar;

	private void Awake()
	{
		
	}

    void setCorrectCanvas()
    {
        
    }
}
