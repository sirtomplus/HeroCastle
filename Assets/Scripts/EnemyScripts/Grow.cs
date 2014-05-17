using UnityEngine;
using System.Collections;

public class Grow : MonoBehaviour {
	private Vector3 growScale;
	// Use this for initialization
	void Start () {
		growScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(1f, growScale.y  * Time.time, 1f);
	}
}
