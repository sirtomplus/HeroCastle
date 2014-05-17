using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {
	public Rigidbody2D melee;
	private PlayerController playerCtrl;
	private bool startUp = false;
//	private bool Active = false;
	
	void Awake () {
		playerCtrl = transform.root.GetComponent<PlayerController>();
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetButtonDown( "Fire2" ) ) {
			startUp = true;
		}
	}

	void FixedUpdate() {
		if( startUp ){
			if( playerCtrl.facingRight ) {
				Rigidbody2D hitBox = Instantiate( melee, transform.position + new Vector3( 0.7f, 0.0f, 0.0f ), Quaternion.Euler( new Vector3( 0, 0, 0 ) ) ) as Rigidbody2D;
				hitBox.transform.parent = gameObject.transform;
			}
			else if( !playerCtrl.facingRight ) {
				Rigidbody2D hitBox = Instantiate( melee, transform.position + new Vector3( -0.7f, 0.0f, 0.0f ), Quaternion.Euler( new Vector3( 0, 0, 180f ) ) ) as Rigidbody2D;
				hitBox.transform.parent = gameObject.transform;
			}
			startUp = false;
		}
/*		if( frameData.frameCount == frameData.activeFrames + frameData.startUpFrames ) {
			Debug.Log ( "Done melee attack" );
//			Active = false;
			startUp = false;
		}*/
	}
}
