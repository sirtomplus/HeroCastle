using UnityEngine;
using System.Collections;

public class SineCurve : MonoBehaviour {
	public float amplitude;		//Peak of deviation from 0
	public float ordinaryFreq;		//# of oscillations each second
	public float theta;				//initial point at t = 0
	private float SineTime = 0f;
	public float initialY;

	private Enemy enemy;

	void Awake(){
		enemy = transform.root.GetComponent<Enemy>();
	}
	// Use this for initialization
	void Start () {
		initialY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector2(transform.position.x + Time.deltaTime * enemy.moveSpeed, initialY + amplitude*Mathf.Sin(2*Mathf.PI*ordinaryFreq*SineTime + theta));
		SineTime += Time.deltaTime*ordinaryFreq;
	}
}
