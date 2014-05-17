using UnityEngine;
using System.Collections;

public class MPPickUp : MonoBehaviour {
	public int MPAmount = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.GetComponentInChildren<PlayerHealth>().RestoreMP(MPAmount);
//			col.gameObject.GetComponent<Gun>().RestoreAmmo(ammoAmount);
			Destroy(this.gameObject);
		}
	}
}
