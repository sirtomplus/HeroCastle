using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
	public GUISkin mySkin;
	private Vector2 scrollPosition;
	private GameObject _optionsMenu;

	void Awake(){
		_optionsMenu = GameObject.Find("OptionsSkin");
	}

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.skin = mySkin;
		GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
		if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 + Screen.height/3, 100, 40), "Back")){
			_optionsMenu.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
