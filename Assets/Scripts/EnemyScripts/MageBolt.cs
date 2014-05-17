using UnityEngine;
using System.Collections;

public class MageBolt : MonoBehaviour {
	public Rigidbody2D Spiral;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Ground"){
			Instantiate(Spiral, new Vector2(transform.position.x, transform.position.y + 4f),
			            Quaternion.Euler(0f, 0f, 0f));
			Destroy(gameObject);
		}
	}


}
