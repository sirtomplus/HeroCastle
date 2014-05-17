using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour {
	public GUISkin mySkin;
	public float BGMSliderValue;
	public float SFXSliderValue;
	private GameObject _mainMenu;
	private GameObject _creditsScreen;
	private string curBGMText;
	private string curSFXText;
	private Volume _volume;

	void Awake(){
		_mainMenu = GameObject.Find("MainMenuSkin");
		_creditsScreen = GameObject.Find ("CreditsSkin");
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
	}

	// Use this for initialization
	void Start () {
		BGMSliderValue = PlayerPrefs.GetFloat("BGMVol", 1.0f);
		SFXSliderValue = PlayerPrefs.GetFloat("SFXVol", 1.0f);
		curBGMText = (BGMSliderValue*100).ToString();
		curSFXText = (BGMSliderValue*100).ToString();
		_volume.setBGMVol(BGMSliderValue);
		_volume.setSFXVol(SFXSliderValue);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	void OnGUI(){
		GUI.skin = mySkin;
		GUI.BeginGroup(new Rect(Screen.width/2-Screen.width/16, Screen.height/4, Screen.width/2, Screen.height/2 + Screen.height/4));
//		BGMSliderValue = GUI.HorizontalSlider(new Rect(Screen.width/2-Screen.width/8, Screen.height/4, Screen.width/4, Screen.height/4), BGMSliderValue, 0f, 1.0f);
		BGMSliderValue = GUI.HorizontalSlider(new Rect(0f, 0f, Screen.width/4, 20f), BGMSliderValue, 0f, 1.0f);
		SFXSliderValue = GUI.HorizontalSlider(new Rect(0, Screen.height/15, Screen.width/4, 20f), SFXSliderValue, 0f, 1.0f);
		_volume.setBGMVol(BGMSliderValue);
		_volume.setSFXVol(SFXSliderValue);
		curBGMText = Mathf.Round(BGMSliderValue*100).ToString();
		curSFXText = Mathf.Round(SFXSliderValue*100).ToString();
		if(GUI.Button(new Rect(0, Screen.height/1.5f, 70, 40), "Back")){
			PlayerPrefs.SetFloat("BGMVol", BGMSliderValue);
			PlayerPrefs.SetFloat("SFXVol", SFXSliderValue);
			_mainMenu.SetActive(true);
			gameObject.SetActive(false);
		}
		if(GUI.Button(new Rect(0, Screen.height/3, 100, 40), "Full Screen") && !Screen.fullScreen){
			Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
		}
		if(GUI.Button(new Rect(Screen.width/12, Screen.height/3, 100, 40), "Windowed") && Screen.fullScreen){
			Screen.SetResolution(1366, 768, false);
		}
		if(GUI.Button(new Rect(0, Screen.height/2.5f, 100, 40), "Delete Save")){
			PlayerPrefs.DeleteAll();
		}
		if(GUI.Button(new Rect(0, Screen.height/2.1f, 100, 40), "Credits")){
			gameObject.SetActive(false);
			_creditsScreen.SetActive(true);
		}
		GUI.Label(new Rect(0f, Screen.height/12, Screen.width/4, 20f), "Up\t\t\t\t\t\tW");
		GUI.Label(new Rect(0f, Screen.height/12+20f, Screen.width/4, 20f), "Down\t\t\t\t\tS");
		GUI.Label(new Rect(0f, Screen.height/12+40f, Screen.width/4, 20f), "Left\t\t\t\t\t\tA");
		GUI.Label(new Rect(0f, Screen.height/12+60f, Screen.width/4, 20f), "Right\t\t\t\t\t\tD");
		GUI.Label(new Rect(0f, Screen.height/12+80f, Screen.width/4, 20f), "Melee\t\t\t\t\tJ");
		GUI.Label(new Rect(0f, Screen.height/12+100f, Screen.width/4, 20f), "Fireball\t\t\t\t\tK");
		GUI.Label(new Rect(0f, Screen.height/12+120f, Screen.width/4, 20f), "Dash\t\t\t\t\t\tL");
		GUI.Label(new Rect(0f, Screen.height/12+140f, Screen.width/4, 20f), "Jump\t\t\t\t\tSpace");
		GUI.Label(new Rect(0f, Screen.height/12+160f, Screen.width/4, 20f), "Fan of Knives\t\tS+K");
		GUI.Label(new Rect(0f, Screen.height/12+180f, Screen.width/4, 20f), "Fire Bottle\t\t\t\tW+K");

		GUI.EndGroup();

		GUI.Label(new Rect(Screen.width/2+Screen.width/5, Screen.height/4-5f, Screen.width/8, Screen.height/8), curBGMText);
		GUI.Label(new Rect(Screen.width/2+Screen.width/5, Screen.height/4+Screen.height/15-5f, Screen.width/8, Screen.height/8), curSFXText);
		GUI.Label(new Rect(Screen.width/2-Screen.width/6, Screen.height/4-5f, Screen.width/8, Screen.height/8), "Music");
		GUI.Label(new Rect(Screen.width/2-Screen.width/6, Screen.height/4+Screen.height/15-5f, Screen.width/8, Screen.height/8), "SFX");



	}
}
