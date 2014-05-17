using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {
	public Rigidbody2D projectile;
	public float speed = 10f;
	public float shotCD;
	public float shotCDRange;
	public float nextShot;

	public Enemy enemy;
	
	void Awake () {
		enemy = transform.root.GetComponent<Enemy>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		if( nextShot < Time.time ){
			if( enemy.facingRight ){
				Rigidbody2D bullet = Instantiate( projectile, transform.position, Quaternion.Euler( new Vector3( 0, 0, 0 ) ) ) as Rigidbody2D;
				bullet.velocity = new Vector2( speed, 0 );
			}
			else{
				Rigidbody2D bullet = Instantiate( projectile, transform.position, Quaternion.Euler( new Vector3( 0, 0, 180f ) ) ) as Rigidbody2D;
				bullet.velocity = new Vector2( -speed, 0 );
			}
			nextShot = Time.time + shotCD + Random.Range( -shotCDRange, shotCDRange );
		}
	}
}
