using UnityEngine;
using System.Collections;

public class FlipEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D( Collision2D col ) {
		if( col.gameObject.tag == "Enemy" ){
			if(col.gameObject.GetComponent<Enemy>().nextFlip < Time.time){
				col.gameObject.GetComponent<Enemy>().Flip ();
				col.gameObject.GetComponent<Enemy>().nextFlip = Time.time + 1.0f;
			}
		}
	}
}
