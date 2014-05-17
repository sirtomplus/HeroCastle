using UnityEngine;
using System.Collections;

public class FireBottle : MonoBehaviour {
	public Rigidbody2D flames;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Ground"){
			Instantiate(flames, 
			            new Vector3(transform.position.x, transform.position.y + 0.5f,transform.position.z),
			            Quaternion.Euler(new Vector3(0f, 0f, 0f)));
			Destroy(gameObject);
		}
		else if(col.tag == "Wall"){
			rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);
		}
	}
}
