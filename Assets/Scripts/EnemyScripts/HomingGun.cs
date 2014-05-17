using UnityEngine;
using System.Collections;

//Must stop targetting when player dies or disable script
public class HomingGun : EnemyGun {
	public Transform Target;

	void Awake(){
		Target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Use this for initialization
	void Start () {
		nextShot = Time.time + shotCD;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		if(nextShot < Time.time){
			Rigidbody2D bullet = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 0f))) as Rigidbody2D;
			bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position - Target.position);
			nextShot = Time.time + shotCD;
		}
	}
}
