using UnityEngine;
using System.Collections;

public class BackToScene : MonoBehaviour {
	
	public string mainMenuName = "LoaderScene";
	public KeyCode key = KeyCode.Escape;
	public bool allowAutoRotation = false;

	public GUISkin skin;

	void Awake() {
		Screen.autorotateToLandscapeLeft = allowAutoRotation;
		Screen.autorotateToLandscapeRight = allowAutoRotation;
		Screen.autorotateToPortrait = allowAutoRotation;
		Screen.autorotateToPortraitUpsideDown = allowAutoRotation;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(key))
		{
			GoBack();
		}
	}
	
	void GoBack() {
		Debug.Log("Loading: Menu");
		Application.LoadLevel(mainMenuName);
	}
	
	void OnGUI() {
		GUI.skin = skin;

		float dpiScaling = GUITools.DpiScaling;
		GUITools.SetFontSizes();

		GUILayout.BeginArea (new Rect(10,Screen.height - 60 * dpiScaling,200 * dpiScaling,50 * dpiScaling));
		
		if(GUILayout.Button ("Back To Menu", GUILayout.Height(50 * dpiScaling), GUILayout.Width(200 * dpiScaling)))
		{
			GoBack();
		}
		
		GUILayout.EndArea();
	}
}
