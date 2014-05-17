using UnityEngine;
using System.Collections;

public class MakeItRain : EnemyGun {
	public float yForce;
	private Animator _anim;

	void Awake(){
		enemy = transform.root.GetComponent<Enemy>();
		_anim = transform.root.GetComponentInChildren<Animator>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate(){
		if(nextShot < Time.time){
			StartCoroutine(Shoot ());
//			for(int i = -1; i < 2; ++i){
//				Rigidbody2D bullet = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 0f))) as Rigidbody2D;
//				bullet.AddForce(new Vector2(0f, yForce));
//				bullet.velocity = new Vector2(speed*i, 0f);
//				bullet.gravityScale = 2;
//			}
//			nextShot = Time.time + shotCD;
		}
	}

	public void enableShower(){
		this.enabled = true;
	}

	IEnumerator Shoot(){
		_anim.SetTrigger("Shoot");
		nextShot = Time.time + shotCD + 0.3f;
		yield return new WaitForSeconds(0.3f);
		for(int i = -1; i < 2; ++i){
			Rigidbody2D bullet = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 0f))) as Rigidbody2D;
			bullet.AddForce(new Vector2(0f, yForce));
			bullet.velocity = new Vector2(speed*i, 0f);
			bullet.gravityScale = 2;
		}

		_anim.ResetTrigger("Shoot");
	}
}
