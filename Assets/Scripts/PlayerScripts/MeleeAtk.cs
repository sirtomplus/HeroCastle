using UnityEngine;
using System.Collections;

public class MeleeAtk : FrameData {
	public int damage;
	private PlayerController playerCtrl;
	private Animator _anim;

	void Awake(){
		playerCtrl = transform.root.GetComponent<PlayerController>();
		_anim = GetComponentInChildren<Animator>();
	}

	// Use this for initialization
	void Start () {
		collider2D.enabled = false;
//		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Only allow attacking if player is not already doing an attack
		if(Input.GetButtonDown("Melee") && !playerCtrl.isActing && !isActive && !playerCtrl.isDead){
			isActive = true;
			playerCtrl.isActing = true;
		}
	}

	void FixedUpdate(){
		if(isActive){
			if(frameCount >= startUpFrames + activeFrames + recoveryFrames){
				isActive = false;
				playerCtrl.isActing = false;
				_anim.ResetTrigger("Attack");
				frameCount = 0;
			}
			else if( frameCount >= startUpFrames + activeFrames ) {
				collider2D.enabled = false;
			}
			else if( frameCount >= startUpFrames ){
//				renderer.enabled = true;
				collider2D.enabled = true;
				_anim.SetTrigger("Attack");
			}

			frameCount++;
		}
	}

	void OnTriggerEnter2D( Collider2D col ) {
		if( col.tag == "Enemy" || col.tag == "Boss" || col.tag == "EnemyTrigger" ){
			col.gameObject.GetComponent<Enemy>().Hurt (damage);
		}
	}
}
