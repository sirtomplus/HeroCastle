﻿using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player"){
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>().Checkpoint(name);
			collider2D.enabled = false;
		}
	}
}
