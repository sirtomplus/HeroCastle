using UnityEngine;
using System.Collections;

public class Gun : FrameData {
	public Rigidbody2D projectile;
	public float speed = 20f;
	public int MPCost;

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
		if(Input.GetAxis("Vertical") == 0 && Input.GetButtonDown( "Fire1" ) && playerResource.MP >= MPCost && !playerCtrl.isActing) {
			playerCtrl.isActing = true;
			isActive = true;
			if(playerCtrl.facingRight) {
				Rigidbody2D bullet = Instantiate( projectile, transform.position, Quaternion.Euler( new Vector3( 0, 0, 0 ) ) ) as Rigidbody2D;
				bullet.velocity = new Vector2( speed, 0 );
			}
			else {
				Rigidbody2D bullet = Instantiate( projectile, transform.position, Quaternion.Euler( new Vector3( 0, 0, 180f ) ) ) as Rigidbody2D;
				bullet.velocity = new Vector2( -speed, 0 );
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
}
