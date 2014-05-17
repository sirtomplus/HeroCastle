using UnityEngine;
using System.Collections;

public class FireBottleGun : FrameData {
	public Rigidbody2D projectile;
	public float speed = 20f;
	public int MPCost;

	private bool up = false;
	
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
		if(Input.GetAxis("Vertical") > 0)
			up = true;
		else
			up = false;

		if(up && Input.GetButtonDown( "Fire1" ) && playerResource.MP >= MPCost && !playerCtrl.isActing && !playerCtrl.isDead) {
			playerCtrl.isActing = true;
			isActive = true;
			if(playerCtrl.facingRight) {
				Rigidbody2D bullet = Instantiate( projectile, transform.position, Quaternion.Euler( new Vector3( 0, 0, 0 ) ) ) as Rigidbody2D;
//				bullet.velocity = new Vector2( speed, -speed/2 );
				bullet.AddForce(new Vector2(250f, 150f));
			}
			else {
				Rigidbody2D bullet = Instantiate( projectile, transform.position, Quaternion.Euler( new Vector3( 0, 0, 180f ) ) ) as Rigidbody2D;
//				bullet.velocity = new Vector2( -speed, -speed/2 );
				bullet.AddForce(new Vector2(-250f, 150f));
			}
			playerResource.UseMP(MPCost);
		}
	}

	void FixedUpdate(){
		if(isActive){
			if(frameCount >= startUpFrames + activeFrames + recoveryFrames){
				playerCtrl.isActing = false;
				isActive = false;
				frameCount = 0;
			}
			
			frameCount++;
		}
	}

	public void enableFireBottle(){
		this.enabled = true;
	}
}
