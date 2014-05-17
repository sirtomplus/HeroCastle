using UnityEngine;
using System.Collections;

public class DoubleJump : MonoBehaviour {
	public float jumpForce;
//	public float maxJumpHeight = 1.3f;
//	private float initialJumpHeight;
	private bool doubleJumping;
	private bool fall;
	private PlayerController playerCtrl;

	void Awake(){
		playerCtrl = transform.root.GetComponent<PlayerController>();
	}

	// Use this for initialization
	void Start () {
		fall = false;
		doubleJumping = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Jump") && !playerCtrl.jump && !playerCtrl.grounded && !fall){
			AudioSource.PlayClipAtPoint(playerCtrl.JumpSound, transform.position, playerCtrl._volume.SFXVol);
			doubleJumping = true;
//			initialJumpHeight = transform.position.y;
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
			Physics2D.IgnoreLayerCollision(8, 9, rigidbody2D.velocity.y > 0);
			Physics2D.IgnoreLayerCollision(8, 0, rigidbody2D.velocity.y > 0);
		}

		if(Input.GetButtonUp("Jump") && doubleJumping){
			fall = true;
		}
	}

	void FixedUpdate(){
		if(doubleJumping && !fall){
//			transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
//			if(transform.position.y >= initialJumpHeight + maxJumpHeight)
//				fall = true;
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			fall = true;
		}
		if(playerCtrl.grounded){
			fall = false;
			doubleJumping = false;
		}
	}

	public void enableDJump(){
		this.enabled = true;
	}
}
