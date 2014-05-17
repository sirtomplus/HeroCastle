using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {
//	public bool passThroughWalls;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player"){
//			col.gameObject.GetComponent<PlayerHealth>().TakeDamage( transform, dmg );
			Destroy( gameObject );
		}
//		if(!passThroughWalls && (col.tag == "Wall" || col.tag == "Ground")){
//			Destroy( gameObject );
//		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			Destroy(gameObject);
		}
	}
}
