using UnityEngine;
using System.Collections;

public class MaxMPIncrease : MonoBehaviour {
	public int increaseAmount;
	public int boostIndex;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.GetComponent<PlayerHealth>().maxMP += increaseAmount;
			col.gameObject.GetComponent<PlayerHealth>().UpdateMaxMPBar();
			col.gameObject.GetComponent<Inventory>().PickupMPBoost(boostIndex);
			col.gameObject.GetComponent<PlayerHealth>().RestoreMP(200);
			Destroy(gameObject);
		}
	}
}
