﻿using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {
	public int healAmount = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.GetComponent<PlayerHealth>().Heal (healAmount);
			Destroy(this.gameObject);
		}
	}
}
