using UnityEngine;
using System.Collections;

public class FrameData : MonoBehaviour {
	public int startUpFrames;		//Frames it takes before the hitbox is active
	public int activeFrames;		//Frames the hitbox is active
	public int recoveryFrames;		//Frames before the player can act again
	public int frameCount;
	public bool isActive;
	// Use this for initialization
	void Start () {
		collider2D.enabled = false;
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
//		if( frameCount >= startUpFrames ){
//			renderer.enabled = true;
//			collider2D.enabled = true;
//		}
//		if( frameCount >= startUpFrames + activeFrames ) {
//			DestroyHitBox();
//		}
//		frameCount++;
	}

	public void DestroyHitBox() {
		if( frameCount == startUpFrames + activeFrames ){
//			Destroy ( this.gameObject );
			renderer.enabled = false;
			collider2D.enabled = false;
		}
	}

}
