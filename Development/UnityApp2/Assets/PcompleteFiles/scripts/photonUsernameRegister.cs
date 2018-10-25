using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class photonUsernameRegister : MonoBehaviour {

	private bool alreadyRegisterd = false;

	public InputField usernameInput;

	public GameObject objectParent;

	public GameObject createButton;

    public TextMeshProUGUI DeviceName;

	void Awake(){
		checkRegister ();
	}


	void checkRegister(){
		if(!alreadyRegisterd){
			objectParent.SetActive (true);
           
        }
	}

	public void usernameInputChange()
	{
		if (usernameInput.text.Length >= 1)
			createButton.SetActive (true);
		else
			createButton.SetActive (false);
	}

	public void createUsername(){
		PhotonNetwork.playerName = usernameInput.text;
		objectParent.SetActive (false);
		Debug.Log ("This machine name is: " + PhotonNetwork.playerName);
    }




}
