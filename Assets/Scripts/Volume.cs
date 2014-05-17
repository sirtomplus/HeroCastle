using UnityEngine;
using System.Collections;

public class Volume : MonoBehaviour {
	public float BGMVol;
	public float SFXVol;
	public GameObject _otherVol;

	void Awake(){
		_otherVol = GameObject.Find ("Volume");
		if(_otherVol != this.gameObject){
			Destroy(gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setBGMVol(float bgmVol){
		BGMVol = bgmVol;
	}

	public void setSFXVol(float sfxVol){
		SFXVol = sfxVol;
	}
}
