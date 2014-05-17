using UnityEngine;
using System.Collections;


public class Charger : Enemy {
//	private GameObject Target;
	public float chargeSpeed = 15f;
	private Transform ChargeHitBox;

	// Use this for initialization
	void Start () {
//		Target = GameObject.FindGameObjectWithTag("Player");
		ChargeHitBox = transform.FindChild ("ChargeHitBox");
		FacePlayer();

		act = false;
		StartCoroutine(InitialWait());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
//		if(act && !isActing){
//			Debug.Log("ACT");
//			action = Random.Range(0, 2);
//			act = false;
//			isActing = true;
//		}
//		Debug.Log(action);
//		if(action == 0){
//			Debug.Log("Charge");
//			Charge ();
//		}
//		else if(action == 1){
//			rigidbody2D.velocity = new Vector2(0f, 0f);
//			if(facingRight){
//				Debug.Log("StepRight");
//				stepRight();
//			}
//			else{
//				Debug.Log("StepLeft");
//				stepLeft();
//			}
//			moveCounter++;
//			if(moveCounter > 5){
//				act = true;
//				isActing = false;
//				moveCounter = 0;
//			}
//		}
		if(HP <= 0){
			transform.parent.GetComponent<Priest>().invulnerable = false;
			Destroy(gameObject);
		}
		if(act){
			Charge ();
			ChargeHitBox.GetComponent<ChargeHitBox>().enableHitBox();
		}

	}

	void OnDestroy(){
		transform.parent.GetComponent<Priest>().gameObject.layer = 10;
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Wall"){
			Debug.Log("Collided with Wall");
//			action = -1;
			ChargeHitBox.GetComponent<ChargeHitBox>().disableHitBox();
			StartCoroutine(BounceOffWall());
		}
	}

	void Charge(){
		if(facingRight){
			rigidbody2D.velocity = new Vector2(chargeSpeed, 0f);
		}
		else if(!facingRight){
			rigidbody2D.velocity = new Vector2(-chargeSpeed, 0f);
		}
	}

//	IEnumerator Walk(){
//		if(facingRight){
//			rigidbody2D.velocity = new Vector2(moveSpeed, 0f);
//		}
//		else if(!facingRight){
//			rigidbody2D.velocity = new Vector2(-moveSpeed, 0f);
//		}
//		yield return new WaitForSeconds(4.0f);
//		act = true;
//	}
	IEnumerator InitialWait(){
		yield return new WaitForSeconds(1.0f);
		act = true;
	}

	IEnumerator Walk(){
		rigidbody2D.velocity = new Vector2(0f, 0f);
		if(facingRight){
			stepRight();
		}
		else{
			stepLeft();
		}
		yield return new WaitForSeconds(0.5f);

		act = true;
//		isActing = false;

	}

	IEnumerator BounceOffWall(){
		act = false;
		rigidbody2D.velocity = new Vector2(0f, 0f);
		if(facingRight){
			rigidbody2D.AddForce(new Vector2(-3000f, 2500f));
		}
		else{
			rigidbody2D.AddForce(new Vector2(3000f, 2500f));
		}

		//Stunned from ramming into wall
		yield return new WaitForSeconds(4.0f);

		//Look at player and wait for next action
		FacePlayer();
		yield return new WaitForSeconds(2.0f);
		act = true;
//		isActing = false;
	}
}
