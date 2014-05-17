using UnityEngine;
using System.Collections;

public class ChildOnCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player" || col.tag == "Enemy"){
			Debug.Log("Player on Top");
			col.gameObject.transform.parent = transform.parent;
		}
	}
	
	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Player" || col.tag == "Enemy"){
			Debug.Log("Player Left");
			col.gameObject.transform.parent = null;
		}
	}
}
