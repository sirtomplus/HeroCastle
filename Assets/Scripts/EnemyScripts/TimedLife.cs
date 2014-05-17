using UnityEngine;
using System.Collections;

public class TimedLife : MonoBehaviour {
	public float timeToLive;
	private float killTime;
	// Use this for initialization
	void Start () {
		killTime = Time.time + timeToLive;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(Time.time > killTime){
			Destroy(gameObject);
		}
	}
}
