using UnityEngine;
using System.Collections;

public class LoopVertically : MonoBehaviour {

	public float vertSpeed;
	public float downSpeed;
	public float upSpeed;
	public float maxHeight;
	public float minHeight;
	private float curHeight;
	public bool goingUp;

	void Awake () {
	}
	// Use this for initialization
	void Start () {
		curHeight = transform.position.y;
		maxHeight += curHeight;
		minHeight += curHeight;
		if(goingUp)
			vertSpeed = upSpeed;
		else
			vertSpeed = downSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		curHeight = transform.position.y;
//		if( curHeight > maxHeight || curHeight < minHeight )
//			vertFlip();
		if(curHeight > maxHeight && goingUp){
//			vertFlip();
			goingUp = !goingUp;
			vertSpeed = downSpeed;
		}
		else if(curHeight < minHeight && !goingUp){
//			vertFlip();
			goingUp = !goingUp;
			vertSpeed = upSpeed;
		}
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, vertSpeed);
	}

	void vertFlip(){
		Vector3 enemyScale = transform.localScale;
		enemyScale.y *= -1;
		transform.localScale = enemyScale;
		goingUp = !goingUp;
	}
	
}
