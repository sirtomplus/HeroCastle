﻿using UnityEngine;
using System.Collections;

public class KnightSceneManager : MonoBehaviour {
	GameObject _player;

	void Awake(){
		_player = GameObject.FindGameObjectWithTag("Player");
	}
	// Use this for initialization
	void Start () {
		if(_player.GetComponent<Inventory>().getBossesKilled(3)){
			Destroy(GameObject.FindGameObjectWithTag("Boss"));
			GameObject.Find("Door").GetComponent<Door>().collider2D.enabled = true;
			
		}
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}