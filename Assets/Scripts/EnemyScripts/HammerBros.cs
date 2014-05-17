using UnityEngine;
using System.Collections;

public class HammerBros : Enemy {
	public int framesBeforeNextAction = 20;
	private int frameCount;
	private bool grounded = false;

	private Transform groundCheck;
	private Leash leash;
	private Animator _anim;

	void Awake(){
		groundCheck = transform.FindChild("groundCheck");
		leash = transform.root.GetComponent<Leash>();
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
		_anim = GetComponentInChildren<Animator>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
			Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("UnpassableGround"));
		_anim.SetBool("Grounded", grounded);

	}

	void FixedUpdate(){
		if(HP <= 0 && !dead){
			Destroy (gameObject);
		}
		if(act){
			FacePlayer();
			if(frameCount >= framesBeforeNextAction){
				int i = Random.Range (0, 3);	//max value is not included in the range
												//Randoms a command
				if(grounded){
					switch(i){
					case 0: Jump ();break;
					case 1: if(!leash.maxRightDistanceReached)
						stepRight();
						break;
					case 2: if(!leash.maxLeftDistanceReached)
						stepLeft();
						break;
					}
				}
				frameCount = 0;
			}
			frameCount++;
		}
	}
}
