using UnityEngine;
using System.Collections;

public class MageGun : MonoBehaviour {
	public Rigidbody2D projectile;
	public float speed;
	private MageBoss _mage;

	void Awake(){
		_mage = transform.parent.GetComponent<MageBoss>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Shoot(){
		if(_mage.getOnRight()){
			Rigidbody2D bullet = Instantiate( projectile, transform.position, Quaternion.Euler( new Vector3( 0, 0, 180f ) ) ) as Rigidbody2D;
			bullet.GetComponentInChildren<Animator>().Play("MageFireballReverse");
			bullet.velocity = new Vector2( -speed, 0f );
		}
		else{
			Rigidbody2D bullet = Instantiate( projectile, transform.position, Quaternion.Euler( new Vector3( 0, 0, 0f ) ) ) as Rigidbody2D;
			bullet.velocity = new Vector2( speed, 0f );
		}
	}
}
