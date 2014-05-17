using UnityEngine;
using System.Collections;

public class BarPosition : MonoBehaviour {
	public Vector3 barPos;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {


	}

	void FixedUpdate(){

	}
	void LateUpdate(){
	}

	public void moveBars(){
		//Positions the object to a point on the screen
		transform.position = Camera.main.ViewportToWorldPoint(barPos);
	}
}
