using UnityEngine;
using System.Collections;

public class BossSceneManager : MonoBehaviour {
	public GameObject _player;
	public int bossNum;
	public AudioClip bossBGM;
	public AudioClip BGM;
	public Volume _volume;
	
	void Awake(){
		_player = GameObject.FindGameObjectWithTag("Player");
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
	}
	// Use this for initialization
	void Start () {
		if(_player.GetComponent<Inventory>().getBossesKilled(bossNum)){
			Destroy(GameObject.FindGameObjectWithTag("Boss"));
			GameObject.Find("Door").GetComponent<Door>().collider2D.enabled = true;
			ChangeBGM();
		}
		else{
			audio.clip = bossBGM;
			StartCoroutine(FadeInBGM());
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeBGM(){
		StartCoroutine(FadeOutBGM());
	}

	public IEnumerator FadeOutBGM(){
		for(float i = _volume.BGMVol; i >= 0; i -= 0.01f){
			audio.volume = i;
			yield return new WaitForFixedUpdate();
		}
		audio.clip = BGM;
		yield return new WaitForSeconds( 0.5f );
		audio.Play();
		StartCoroutine(FadeInBGM());
	}

	public IEnumerator FadeInBGM(){
		for(float i = 0; i <= _volume.BGMVol; i += 0.01f){
			audio.volume = i;
			yield return new WaitForFixedUpdate();
		}
	}
}
