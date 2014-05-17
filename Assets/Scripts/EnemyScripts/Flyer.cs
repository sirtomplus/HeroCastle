using UnityEngine;
using System.Collections;

public class Flyer : Enemy {

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(moveSpeed, 0f);
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		if(transform.localPosition.x > 12f && facingRight){
			StartCoroutine(ChangeSpeed());
		}
		else if(transform.localPosition.x < -9f && !facingRight){
			StartCoroutine(ChangeSpeed ());
		}

	}


	IEnumerator ChangeSpeed(){
		moveSpeed = -moveSpeed;
		rigidbody2D.velocity = new Vector2(moveSpeed, 0f);
		yield return new WaitForFixedUpdate();
		rigidbody2D.velocity = new Vector2(0f, 0f);
		yield return new WaitForSeconds(2.0f);
		Flip ();
//		moveSpeed = -moveSpeed;
		rigidbody2D.velocity = new Vector2(moveSpeed, 0f);
	}
}
