using UnityEngine;
using System.Collections;

//rigidbody2D.velocity method: Player can't move while on platform due to friction
//transform.position method: Player doesn't stay on platform
public class MovePlatform : MonoBehaviour {
	public float speedX;
	public float speedY;
	public float maxX;
	public float minX;
	public float maxY;
	public float minY;

	private float nextFlip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		transform.position = new Vector3(transform.position.x + speedX, transform.position.y + speedY, 0);
		rigidbody2D.velocity = new Vector2(speedX, speedY);
		if(transform.position.x > maxX || transform.position.x < minX || transform.position.y > maxY || transform.position.y < minY){
			if(nextFlip < Time.time)
				Flip ();
		}
	}



	public void Flip(){
		speedX *= -1;
		speedY *= -1;
		nextFlip = Time.time + 1.0f;
	}
}
