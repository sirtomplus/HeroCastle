using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public GUISkin mySkin;

	//Icons
//	public Texture2D KnightIcon;
	public Texture2D FirebottleCommandTexture;
	public Texture2D KnivesCommandTexture;
	public Texture2D DoubleJumpCommandTexture;
	public Texture2D ShootTexture;
	public Texture2D BlueKeyTexture;
	public Texture2D GreenKeyTexture;
	public Texture2D RedKeyTexture;

	//Reference to players inventory to know what to display
	private Inventory _inventory;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		_inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		DontDestroyOnLoad(this);
		this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Unpause
		//For some reason this Update is still called even though timescale is 0
		if(Input.GetButtonDown("Start")){
			Time.timeScale = 1;
			this.enabled = false;
		}
	}

	void OnGUI(){
		GUI.Box (new Rect(0, 0, Screen.width, Screen.height), "");
		GUI.Box (new Rect(Screen.width/2 - 100, Screen.height/2 - 80, 200, 40), "Press Enter to resume");


		//Command list
		GUI.Label (new Rect(30, 140, 300, 40), "Fireball");
		GUI.Label (new Rect(300, 120, 600, 60), new GUIContent(ShootTexture));
		if(_inventory.GetDJump()){
			GUI.Label(new Rect(30, 200, 300, 40), "Mage's Cape");
			GUI.Label(new Rect(300, 180, 600, 60), new GUIContent(DoubleJumpCommandTexture));
		}
		if(_inventory.GetFireBottle()){
			GUI.Label(new Rect(30, 200+80, 300, 40), "Fire Bottle");
			GUI.Label(new Rect(300, 180+80, 600, 60), new GUIContent(FirebottleCommandTexture));
		}
		if(_inventory.GetKnives()){
			GUI.Label(new Rect(30, 200+160, 300, 40), "Knives");
			GUI.Label (new Rect(300, 180+160, 600, 60), new GUIContent(KnivesCommandTexture));
		}

		//Keys
		GUI.Label (new Rect(120, Screen.height/2+Screen.height/8, 100, 40), "Keys");
		if(_inventory.GetKey(0)){
			GUI.Label(new Rect(30, 11*Screen.height/16, 150, 150), new GUIContent(BlueKeyTexture));
		}
		if(_inventory.GetKey(1)){
			GUI.Label(new Rect(140, 11*Screen.height/16, 150, 150), new GUIContent(GreenKeyTexture));
		}
		if(_inventory.GetKey(2)){
			GUI.Label(new Rect(250, 11*Screen.height/16, 150, 150), new GUIContent(RedKeyTexture));
		}

		//Bosses killed
//		GUI.Label(new Rect(Screen.width/2 + Screen.width/3, 50, 100, 40), "Heroes Slain");
//		GUI.Label (new Rect(Screen.width/2+Screen.width/4, 100, 60, 60), new GUIContent(KnightIcon));

		if(GUI.Button(new Rect(Screen.width-100, Screen.height-100, 100, 40), "Save Game")){
			//Save the game
			Transform gameMaster = GameObject.FindGameObjectWithTag("GameController").transform;
			gameMaster.GetComponent<SaveManager>().Save();
		}

		if(GUI.Button(new Rect(Screen.width-100, Screen.height-40, 100, 40), "Exit Game")){
			//Back to main menu
			Destroy(GameObject.FindGameObjectWithTag("Player"));
			Destroy(GameObject.FindGameObjectWithTag("GameController"));
			Destroy(GameObject.FindGameObjectWithTag ("BarsAnchor"));
			Application.LoadLevel("MainMenu");
			Time.timeScale = 1;
			Destroy(this.gameObject);
		}
		
	}

	public void enablePauseMenu(){
		this.enabled = true;
	}
}
