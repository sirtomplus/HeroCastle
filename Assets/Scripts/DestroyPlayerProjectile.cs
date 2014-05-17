using UnityEngine;
using System.Collections;

public class DestroyPlayerProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Bullet"){
			Destroy(col.gameObject);
		}
	}
}
