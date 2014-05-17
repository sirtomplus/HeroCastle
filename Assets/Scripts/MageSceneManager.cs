using UnityEngine;
using System.Collections;

//Kill the boss if the player already has
public class MageSceneManager : BossSceneManager {
//	public GameObject _player;
	public GameObject _teleporter;
	public GameObject _door;

	void Awake(){
		_player = GameObject.FindGameObjectWithTag("Player");
		_teleporter = GameObject.FindGameObjectWithTag ("Door");
		_door = GameObject.Find("Door");
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
	}

	// Use this for initialization
	void Start () {
		if(_player.GetComponent<Inventory>().getBossesKilled(1)){
			_teleporter.SetActive(true);
			Destroy(GameObject.FindGameObjectWithTag("Boss"));
			Destroy(GameObject.FindGameObjectWithTag("Spawner"));
			ChangeBGM();
		}
		else{
			_teleporter.SetActive(false);
			_door.collider2D.enabled = false;
			audio.clip = bossBGM;
			StartCoroutine(FadeInBGM());
		}
//		StartCoroutine(FadeInBGM());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	IEnumerator FadeInBGM(){
//		for(float i = 0; i <= 1.0; i += 0.01f){
//			audio.volume = i;
//			yield return new WaitForFixedUpdate();
//		}
//	}
}
