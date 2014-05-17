using UnityEngine;
using System.Collections;

public class HomingBullet : EnemyProjectile {
	public float speed = 10f;

	void Awake(){

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		transform.position += transform.up *(speed * Time.deltaTime);
	}
}
