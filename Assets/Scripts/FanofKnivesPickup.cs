using UnityEngine;
using System.Collections;

public class FanofKnivesPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
//			col.gameObject.GetComponentInChildren<FanOfKnives>().enableFanOfKnives();
			col.gameObject.GetComponent<Inventory>().PickUpKnives();
			col.gameObject.GetComponent<PlayerHealth>().Heal(200);
			Destroy(gameObject);
		}
	}
}
