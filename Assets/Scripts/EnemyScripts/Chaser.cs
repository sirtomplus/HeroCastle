using UnityEngine;
using System.Collections;

public class Chaser : Enemy {
	private Animator _anim;

	//Remove Awake function and add _anim to Enemy class after getting animations for all
	//Objects that use the Enemy class
	void Awake () {
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
		_anim = GetComponentInChildren<Animator>();
		initItems();
	}
	// Use this for initialization
	void Start () {
		StartCoroutine(WaitAndChase());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator WaitAndChase(){
		act = false;
		transform.FindChild("HitBox").collider2D.enabled = false;
		yield return new WaitForSeconds(2.0f);
		FacePlayer();
		transform.FindChild("HitBox").collider2D.enabled = true;
		act = true;
		_anim.SetBool("Act", act);
	}
}
