using UnityEngine;
using System.Collections;

public class TripleBullet : MonoBehaviour {
	public Rigidbody2D projectile;
	public Rigidbody2D deflectableProjectile;
	public float offsetAngle;
	public float timeBetweenShots;
	private float nextShot;
	private int bulletsToShoot = 3;
	private int bulletCount;
	private bool deflectFired = false;

	private Transform _target;

	void Awake(){
		_target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(Time.time > nextShot){
			if(bulletCount < bulletsToShoot){
				if(!deflectFired){
					if(Random.Range (0, 2) == 0){
						Rigidbody2D bullet = Instantiate(deflectableProjectile, transform.position, Quaternion.LookRotation(Vector3.forward, _target.position - transform.position
						                                                                                         )) as Rigidbody2D;
						bullet.transform.Rotate(0f, 0f, Random.Range(-offsetAngle, offsetAngle));
						deflectFired = true;
					}
					else{
						if(bulletCount == 2 && !deflectFired){
							Rigidbody2D bullet = Instantiate(deflectableProjectile, transform.position, Quaternion.LookRotation(Vector3.forward, _target.position - transform.position
	                                                                                             )) as Rigidbody2D;
							bullet.transform.Rotate(0f, 0f, Random.Range(-offsetAngle, offsetAngle));

						}
						else{
							Rigidbody2D bullet = Instantiate(projectile, transform.position, Quaternion.LookRotation(Vector3.forward, _target.position - transform.position)) as Rigidbody2D;
							bullet.transform.Rotate(0f, 0f, Random.Range(-offsetAngle, offsetAngle));

						}
					}
				}
				else{
					Rigidbody2D bullet = Instantiate(projectile, transform.position, Quaternion.LookRotation(Vector3.forward, _target.position - transform.position
				                                                                                         )) as Rigidbody2D;
					bullet.transform.Rotate(0f, 0f, Random.Range(-offsetAngle, offsetAngle));

				}
//				bullet.transform.Rotate(0f, 0f, Random.Range(-offsetAngle, offsetAngle));
				nextShot = Time.time + timeBetweenShots;
				bulletCount++;
			}
			else{
				Destroy(gameObject);
			}
		}
	}
}
