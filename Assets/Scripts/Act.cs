using UnityEngine;
using System.Collections;

public class Act : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Spawner"){
			col.gameObject.GetComponent<Spawner>().isActive = true;
		}
	}

	//Doesn't work
	//Objects do not exit if they are not moving
	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag == "Spawner"){
			col.gameObject.GetComponent<Spawner>().isActive = false;
		}
	}
}
