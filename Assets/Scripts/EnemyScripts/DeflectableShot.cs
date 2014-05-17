using UnityEngine;
using System.Collections;

public class DeflectableShot : MonoBehaviour {
	private Transform _deflectToTarget;
	private bool deflected = false;
	public float deflectSpeed;
	public float speed;

	void Awake(){
		_deflectToTarget = GameObject.FindGameObjectWithTag("Boss").transform;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(deflected){
//			transform.rotation = Quaternion.LookRotation(Vector3.forward, _deflectToTarget.position - transform.position);
			transform.position += transform.up *(deflectSpeed * Time.deltaTime);
		}
		else{
			transform.position += transform.up * (speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Melee"){
			gameObject.layer = 12;
			Deflect();
		}
		else if(col.tag == "Boss" && deflected){
			Destroy(gameObject);
		}
		else if(col.tag == "Player" && !deflected){
			Destroy(gameObject);
		}
	}

	public void Deflect(){
		deflected = true;
		transform.rotation = Quaternion.LookRotation(Vector3.forward, _deflectToTarget.position - transform.position);
	}
}
