using UnityEngine;
using System.Collections;

public class LowerGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player"){
			Debug.Log("Player Entered");
			col.rigidbody2D.gravityScale = 1f;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Player"){
			col.rigidbody2D.gravityScale = 3.5f;
		}
	}
}
