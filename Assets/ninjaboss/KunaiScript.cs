using UnityEngine;
using System.Collections;

public class KunaiScript : MonoBehaviour {

	public float kunaiSpeed;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void FixedUpdate()
	{
		transform.Translate (Vector3.right * Time.deltaTime * kunaiSpeed);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Wall" || col.gameObject.tag == "Player"
		   || col.gameObject.tag == "Ground")
		{
			Destroy(gameObject);
		}
	}
}
