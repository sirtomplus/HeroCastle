using UnityEngine;
using System.Collections;

public class DJumpPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.GetComponent<Inventory>().PickUpDoubleJump();
			col.gameObject.GetComponent<PlayerHealth>().Heal(200);
			Destroy(gameObject);
		}
	}
}
