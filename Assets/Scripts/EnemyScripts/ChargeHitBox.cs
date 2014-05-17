using UnityEngine;
using System.Collections;

public class ChargeHitBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		disableHitBox();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player"){
			disableHitBox();
		}
	}

	public void enableHitBox(){
		renderer.enabled = true;
		collider2D.enabled = true;
	}

	public void disableHitBox(){
		renderer.enabled = false;
		collider2D.enabled = false;
	}
}
