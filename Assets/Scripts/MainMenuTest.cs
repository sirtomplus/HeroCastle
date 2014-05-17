using UnityEngine;
using System.Collections;

public class MainMenuTest : MonoBehaviour {
	public GUISkin mySkin;
//	public bool show = false;
//	private bool main = true;
//	private bool credits = false;
	private GameObject _optionsMenu;

	void Awake(){
		_optionsMenu = GameObject.Find("OptionsSkin");
	}

	// Use this for initialization
	void Start () {
		_optionsMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.GetButtonDown("Start")){
//			show = !show;
//		}
	}

	void OnGUI(){
		GUI.skin = mySkin;
		GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
		if(GUI.Button(new Rect(Screen.width/2, Screen.height/2, 100, 40), "New Game")){
			Application.LoadLevel("NewGameScene");
		}
		else if(GUI.Button(new Rect(Screen.width/2, Screen.height/2 + 50, 100, 40), "Continue")){
			if(PlayerPrefs.GetInt("SaveData", 0) == 1){
				Application.LoadLevel("LoadingScene");
			}

		}
		else if(GUI.Button(new Rect(Screen.width/2, Screen.height/2 + 100, 100, 40), "Options")){
			_optionsMenu.SetActive(true);
			gameObject.SetActive(false);
		}
		else if(GUI.Button(new Rect(Screen.width - 100, Screen.height - 40, 100, 40), "Exit")){
			Application.Quit();
		}
		else if(GUI.Button(new Rect(0f, Screen.height - 40, 100, 40), "Delete Save")){
			PlayerPrefs.DeleteAll();
		}
	}
}
