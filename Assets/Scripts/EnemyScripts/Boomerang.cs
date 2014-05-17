using UnityEngine;
using System.Collections;

public class Boomerang : MonoBehaviour {
	public float maxDistance;
	public int damage = 2;
	private float initialPosition;
	private bool isReturning;
	bool goRight;
	public Enemy parentEnemy;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		initialPosition = transform.position.x;
		isReturning = false;

		if(parentEnemy.facingRight){
			goRight = true;
			maxDistance = -maxDistance;
		}
		else
			goRight = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(!goRight && initialPosition > transform.position.x + maxDistance){
			Flip ();
			isReturning = true;
		}
		else if(goRight && initialPosition < transform.position.x + maxDistance){
			Flip();
			isReturning = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if((col.tag == "Enemy" || col.tag == "Boss") && isReturning){
			col.GetComponent<Knight>().EnableShield();
			Destroy(gameObject);
		}
	}

	void Flip(){
		rigidbody2D.velocity = new Vector2(-rigidbody2D.velocity.x, 0f);
	}
}
