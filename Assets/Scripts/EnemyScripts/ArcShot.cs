using UnityEngine;
using System.Collections;

public class ArcShot : MonoBehaviour {
	public float minYForce;
	public float maxYForce;
	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce(new Vector2(0, Random.Range (minYForce, maxYForce)));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

	}
}
