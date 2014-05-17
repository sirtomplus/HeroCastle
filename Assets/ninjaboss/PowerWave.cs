using UnityEngine;
using System.Collections;

public class PowerWave : MonoBehaviour {

	public float speed;
	public float waveIncrease;
	Transform powerTransform;
	// Use this for initialization
	void Start () 
	{
		powerTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void FixedUpdate()
	{
		transform.Translate (Vector3.right * (Time.deltaTime * speed));
		powerTransform.localScale += new Vector3(0.0f, waveIncrease, 0.0f);
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Wall" || col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
