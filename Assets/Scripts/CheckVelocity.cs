using UnityEngine;
using System.Collections;

public class CheckVelocity : MonoBehaviour {
	public Vector2 _velocity;
	

	// Use this for initialization
	void Start () {
		_velocity = rigidbody2D.velocity;
	}
	
	// Update is called once per frame
	void Update () {
		_velocity = rigidbody2D.velocity;
	}
}
