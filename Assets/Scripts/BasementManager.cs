using UnityEngine;
using System.Collections;

public class BasementManager : MonoBehaviour {
	GameObject _player;
	private Volume _volume;
	
	void Awake(){
		_player = GameObject.FindGameObjectWithTag("Player");
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
	}

	// Use this for initialization
	void Start () {
		if(_player.GetComponent<Inventory>().GetKey(1)){
			Destroy(GameObject.Find ("Key1"));
		}
		if(_player.GetComponent<Inventory>().getHPBoost(0)){
			Destroy(GameObject.Find ("HPBoost0"));
		}
		StartCoroutine(FadeInBGM());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator FadeInBGM(){
		for(float i = 0; i <= _volume.BGMVol; i += 0.01f){
			audio.volume = i;
			yield return new WaitForFixedUpdate();
		}
	}
}
