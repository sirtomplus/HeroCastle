using UnityEngine;
using System.Collections;

public class GameMasterNew : GameMaster {
	
	void Awake(){
		DontDestroyOnLoad(this);
		_saveManager = transform.root.GetComponent<SaveManager>();
		Instantiate(Bars, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
		Rigidbody2D player = Instantiate(Player, new Vector3(-50f,50f,0f), Quaternion.Euler(0f,0f,0f)) as Rigidbody2D;
	}
	// Use this for initialization
	void Start () {

		nextSpawnLocation = "FrontDoorSpawn";
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		_player.GetComponent<Inventory>().ResetAll();
		DontDestroyOnLoad(_player);
		lastScene = "WestWing";
		Application.LoadLevel(lastScene);

		savedHP = 100;
		savedMP = 100;

	}
	
	// Update is called once per frame
//	void Update () {
//		currentScene = Application.loadedLevelName;
//		if(currentScene != lastScene){
//			lastScene = currentScene;
// 			StartCoroutine(newScene());
//		}
//		if(Input.GetButtonDown("Start") && _player.GetComponent<PlayerController>().isDead){
//			revivePlayer();
//			Application.LoadLevel(lastScene);
//			StartCoroutine(newScene());
//		}
//	}
	
}
