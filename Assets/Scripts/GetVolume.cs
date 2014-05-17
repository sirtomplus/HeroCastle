using UnityEngine;
using System.Collections;

public class GetVolume : MonoBehaviour {
	private Volume _volume;

	void Awake(){
		_volume = GameObject.Find("Volume").GetComponent<Volume>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		audio.volume = _volume.BGMVol;
	}
}
