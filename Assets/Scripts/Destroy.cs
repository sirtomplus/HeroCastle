using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void OnCollisionExit2D( Collision2D col ) {
//		Destroy( col.gameObject );
//	}

	void OnTriggerExit2D( Collider2D col ) {
		Destroy( col.gameObject );
	}
}
