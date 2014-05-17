using UnityEngine;
using System.Collections;

public class FanOfKnives : FrameData {
	public Rigidbody2D projectile;
	public float speed = 20f;
	public int MPCost;

	private bool down = false;
	
	private PlayerController playerCtrl;
	private PlayerHealth playerResource;

	void Awake () {
		playerCtrl = transform.root.GetComponent<PlayerController>();
		playerResource = transform.root.GetComponent<PlayerHealth>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Vertical") < 0)
			down = true;
		else
			down = false;
		if(down && Input.GetButtonDown( "Fire1" ) && playerResource.MP >= MPCost && !playerCtrl.isActing && playerCtrl.grounded && !playerCtrl.isDead) {
			playerCtrl.isActing = true;
			playerCtrl.canMove = false;
			isActive = true;
//			if(playerCtrl.facingRight) {
//				Rigidbody2D bullet = Instantiate( projectile, transform.position, Quaternion.Euler( new Vector3( 0, 0, 0 ) ) ) as Rigidbody2D;
//				bullet.velocity = new Vector2( speed, 0 );
//			}
			for(int i = 0; i < 9; ++i){
				Rigidbody2D bullet = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 0f))) as Rigidbody2D;
				bullet.velocity = new Vector2(Mathf.Cos (Mathf.Deg2Rad*(22.5f*i))*speed, Mathf.Sin(Mathf.Deg2Rad*(22.5f*i))*speed);
			}
			playerResource.UseMP(MPCost);
		}
	}
	
	void FixedUpdate(){
		if(isActive){
			if(frameCount >= startUpFrames + activeFrames + recoveryFrames){
				playerCtrl.isActing = false;
				playerCtrl.canMove = true;
				isActive = false;
				frameCount = 0;
			}
			
			frameCount++;
		}
	}

	public void enableFanOfKnives(){
		this.enabled = true;
	}
}
