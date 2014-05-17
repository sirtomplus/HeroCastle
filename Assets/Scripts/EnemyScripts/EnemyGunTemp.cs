using UnityEngine;
using System.Collections;

public class EnemyGunTemp : MonoBehaviour {
	public Rigidbody2D projectile;
	public float speed = 10f;
	public float shotCD;
	public float shotCDRange;
	public float nextShot;
	
	public Enemy enemy;
	private Animator _anim;
	
	void Awake () {
		enemy = transform.root.GetComponent<Enemy>();
		_anim = transform.root.GetComponentInChildren<Animator>();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
		if( nextShot < Time.time ){
			StartCoroutine(Shoot());
//			_anim.SetTrigger("Shoot");
//			if( enemy.facingRight ){
//				Rigidbody2D bullet = Instantiate( projectile, transform.position, Quaternion.Euler( new Vector3( 0, 0, 0 ) ) ) as Rigidbody2D;
//				bullet.velocity = new Vector2( speed, 0 );
//			}
//			else{
//				Rigidbody2D bullet = Instantiate( projectile, transform.position, Quaternion.Euler( new Vector3( 0, 0, 180f ) ) ) as Rigidbody2D;
//				bullet.velocity = new Vector2( -speed, 0 );
//			}
//			nextShot = Time.time + shotCD + Random.Range( -shotCDRange, shotCDRange );
//			_anim.ResetTrigger("Shoot");
		}
	}

	IEnumerator Shoot(){
		_anim.SetTrigger("Shoot");
		nextShot = Time.time + shotCD + Random.Range( -shotCDRange, shotCDRange ) + 0.3f;
		yield return new WaitForSeconds(0.3f);
		if( enemy.facingRight ){
			Rigidbody2D bullet = Instantiate( projectile, transform.position, Quaternion.Euler( new Vector3( 0, 0, 0 ) ) ) as Rigidbody2D;
			bullet.velocity = new Vector2( speed, 0 );
		}
		else{
			Rigidbody2D bullet = Instantiate( projectile, transform.position, Quaternion.Euler( new Vector3( 0, 0, 180f ) ) ) as Rigidbody2D;
			bullet.velocity = new Vector2( -speed, 0 );
		}

		_anim.ResetTrigger("Shoot");
	}
}

