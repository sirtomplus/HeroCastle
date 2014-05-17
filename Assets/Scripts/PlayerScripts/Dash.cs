using UnityEngine;
using System.Collections;

//Tried to separate the dash from the PlayerController class
//Didn't work out as well, maybe next time
public class Dash : MonoBehaviour {
	[HideInInspector]
	public bool dashing = false;

	public int maxDashFrames = 12;
	public float dashSpeed;

	private int dashFramesCount;

	private PlayerController playerCtrl;

	void Awake(){
		playerCtrl = transform.root.GetComponent<PlayerController>();
	}

	// Use this for initialization
	void Start () {
		dashSpeed = playerCtrl.maxSpeed * 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Dash") && playerCtrl.grounded){
			dashing = true;
			dashFramesCount = 0;
		}
		if(Input.GetButtonUp("Dash") || dashFramesCount >= maxDashFrames){
			dashing = false;
			dashFramesCount = 0;
		}
	}

	void FixedUpdate(){
		if(dashing){
			if(playerCtrl.facingRight)
				playerCtrl.horizVel = dashSpeed;
			else
				playerCtrl.horizVel = -dashSpeed;
			dashFramesCount++;
		}
	}
}
