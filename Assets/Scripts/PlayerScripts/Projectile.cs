using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public int damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D( Collider2D col ) {
		if( col.tag == "Enemy" || col.tag == "Boss" ){
			col.gameObject.GetComponent<Enemy>().Hurt(damage);
			Destroy( gameObject );
		}
		else if( col.tag == "Wall" || col.tag == "Ground" ){
			Destroy( gameObject );
		}
	}
}
