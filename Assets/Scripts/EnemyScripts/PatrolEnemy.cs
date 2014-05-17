using UnityEngine;
using System.Collections;

public class PatrolEnemy : Enemy {
	private Leash leash;
	public bool goLeft;
	public bool goRight;
	public float idleTime;
	public Vector2 _velocity;

	private Animator anim;


	void Awake(){
		leash = transform.root.GetComponent<Leash>();
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
//		anim = GetComponent<Animator>();
		anim = GetComponentInChildren<Animator>();
	}

	// Use this for initialization
	void Start () {
		if(facingRight){
			goRight = true;
			goLeft = false;
		}
		else if(!facingRight){
			goRight = false;
			goLeft = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		if(HP <= 0 && !dead){
			Destroy(gameObject);
		}
		if(facingRight && leash.maxRightDistanceReached){
			goLeft = true;
			goRight = false;
			StartCoroutine(WaitForFlip());
		}
		else if(!facingRight && leash.maxLeftDistanceReached){
			goLeft = false;
			goRight = true;
			StartCoroutine(WaitForFlip());
		}

		if(act){
			if(goRight){
				rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
			}
			else if(goLeft){
				rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
			}
		}
		anim.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
	}

	IEnumerator WaitForFlip(){
		rigidbody2D.velocity = new Vector2(0f, 0f);
		Flip ();
		act = false;
		yield return new WaitForSeconds(idleTime);
		act = true;
	}
}
