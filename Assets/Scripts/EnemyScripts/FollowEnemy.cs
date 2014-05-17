using UnityEngine;
using System.Collections;

public class FollowEnemy : Enemy {
	private Transform _target;

	void Awake(){
		_target = GameObject.FindGameObjectWithTag("Player").transform;
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
	}

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
		transform.position += transform.up *(moveSpeed * Time.deltaTime);
	}

	void LateUpdate(){
		transform.rotation = Quaternion.LookRotation(Vector3.forward, _target.position - transform.position);
	}
}
