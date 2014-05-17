using UnityEngine;
using System.Collections;

public class JumpThroughPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			Debug.Log("Collision");
			Physics2D.IgnoreLayerCollision(8, 9, col.transform.rigidbody2D.velocity.y > 0);
		}
	}
}
