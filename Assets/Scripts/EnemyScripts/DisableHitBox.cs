using UnityEngine;
using System.Collections;

//Disable the hitbox of a damaging object
//Do this because of objects that don't destroy themselves on collision
//will damage the player twice before being knocked away
public class DisableHitBox : MonoBehaviour {
	public float DisableTime = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player"){
			StartCoroutine(DisableCollider());
		}
	}
	

	IEnumerator DisableCollider(){
		collider2D.enabled = false;
		yield return new WaitForSeconds(DisableTime);
		collider2D.enabled = true;
	}
}
