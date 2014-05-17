using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	[HideInInspector]
	public bool facingRight;
	[HideInInspector]
	public bool jump = false;
	[HideInInspector]
	public bool dashing = false;
	[HideInInspector]
	public bool grounded = false;
	[HideInInspector]
	public bool canMove = true;
	[HideInInspector]
	public float horizVel;
	[HideInInspector]
	public bool isActing = false;
	[HideInInspector]
	public bool isDead = false;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public int maxDashFrames = 5;
	private float dashSpeed;
	public float jumpForce = 100f;
	private bool dashRight = false;

	private float totalJumpForce = 0f;
	public float maxJumpForce = 500f;

	private Transform groundCheck;
	private int dashFramesCount;
	private Transform pauseMenu;

	[HideInInspector]
	public float nextPause;

	public AudioClip JumpSound;
	public Volume _volume;

//	private Animator _anim;
	void Awake() {
		groundCheck = transform.FindChild("groundCheck");
		pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu").transform;
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
//		_anim = GetComponent<Animator>();

	}

	// Use this for initialization
	void Start () {
		dashSpeed = maxSpeed * 2;
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
			Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("UnpassableGround"));

		//Cooldown on pause because it will stay paused forever without it
		if(Input.GetButtonDown("Start") && Time.time > nextPause){
			nextPause = .1f + Time.time;
			pauseMenu.GetComponent<PauseMenu>().enablePauseMenu();
			Time.timeScale = 0;
		}

		if(Input.GetButtonDown("Dash") && grounded){
			dashing = true;
			dashFramesCount = 0;
			dashRight = facingRight;
		}

		if(Input.GetButtonDown("Jump") && grounded){
			AudioSource.PlayClipAtPoint(JumpSound, transform.position, _volume.SFXVol);
			jump = true;
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
		}

		//Releasing the jump button
		if(Input.GetButtonUp("Jump")) {
			jump = false;
			totalJumpForce = 0;
		}
		//Reached highest jump height of first jump but haven't double jumped
		else if(totalJumpForce >= maxJumpForce){
			jump = false;
			totalJumpForce = 0;
		}

		if((Input.GetButtonUp("Dash") || dashFramesCount >= maxDashFrames || dashRight != facingRight) && grounded){
			dashing = false;
		}

	}

	void FixedUpdate() {
		float h = Input.GetAxis("Horizontal");
//		_anim.SetFloat("Speed", Mathf.Abs (h));
		if(canMove && !isDead){
			if(dashing){
				if(facingRight)
					horizVel = dashSpeed;
				else
					horizVel = -dashSpeed;
				dashFramesCount++;

			}
			else if( h == 0 ){
				horizVel = 0;
			}
			else{
				// calculate adding the force ourselves: acceleration = Force/mass ... and clamp the velocity 
				horizVel = Mathf.Clamp(horizVel + h * (moveForce/rigidbody2D.mass) * Time.deltaTime, -maxSpeed, maxSpeed);
			}

			Vector3 vel = rigidbody2D.velocity;
			vel.x = horizVel;
			rigidbody2D.velocity = vel;


			if(h > 0 && !facingRight) {
				Flip();
			}
			else if(h < 0 && facingRight) {
				Flip ();
			}

			if(jump) {
				Jump();
			}

		}
		Physics2D.IgnoreLayerCollision(8, 9, rigidbody2D.velocity.y > 0);
		Physics2D.IgnoreLayerCollision(8, 0, rigidbody2D.velocity.y > 0);
	}


	void Flip() {
		facingRight = !facingRight;
		rigidbody2D.velocity = new Vector3(0f, rigidbody2D.velocity.y, 0f);
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Jump(){
		//Add force a little bit at a time so the player can hold 
		//the button down longer for a higher jump
		rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		totalJumpForce += jumpForce;
	}
	
}
