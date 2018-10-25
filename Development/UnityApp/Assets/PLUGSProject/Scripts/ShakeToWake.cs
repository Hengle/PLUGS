using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShakeToWake : MonoBehaviour {

    public GameObject wakeScreen;

    Vector3 accelerationDir;

	
	// Update is called once per frame
	void Update () {
        accelerationDir = Input.acceleration;

        if (accelerationDir.sqrMagnitude >= 5f)
        {
            wakeScreen.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
	}
}
