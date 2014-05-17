using UnityEngine;
using System.Collections;

public class MaxHPIncrease : MonoBehaviour {
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
			col.gameObject.GetComponent<PlayerHealth>().maxHealth += increaseAmount;
			if(increaseAmount == 50){
				col.gameObject.GetComponent<PlayerHealth>().UpdateMaxHealthBar();
				col.gameObject.GetComponent<PlayerHealth>().UpdateMaxHealthBar();
			}
			else{
				col.gameObject.GetComponent<PlayerHealth>().UpdateMaxHealthBar();
			}
			col.gameObject.GetComponent<Inventory>().PickupHPBoost(boostIndex);
			col.gameObject.GetComponent<PlayerHealth>().Heal(200);
			Destroy(gameObject);
		}
	}
}
