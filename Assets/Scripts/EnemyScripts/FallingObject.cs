using UnityEngine;
using System.Collections;

public class FallingObject : Enemy {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		if(HP <= 0){
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Ground"){
			gameObject.layer = 10;
		}
	}
}
