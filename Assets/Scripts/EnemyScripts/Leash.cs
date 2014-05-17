using UnityEngine;
using System.Collections;

//Keeps enemy on a leash on the X axis only
public class Leash : MonoBehaviour {
	private Enemy enemy;
	public float maxLeashRange;
	public float initialX;
	public float distanceX;
	public bool maxLeftDistanceReached = false;
	public bool maxRightDistanceReached = false;
//	public float initialY;

	void Awake(){
		enemy = transform.root.GetComponent<Enemy>();
	}

	// Use this for initialization
	void Start () {
		initialX = enemy.transform.position.x;
//		initialY = enemy.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		distanceX = enemy.transform.position.x - initialX;
		if(distanceX <= -maxLeashRange){
			maxLeftDistanceReached = true;
		}
		else if(distanceX >= maxLeashRange){
			maxRightDistanceReached = true;
		}
		else{
			maxLeftDistanceReached = false;
			maxRightDistanceReached = false;
		}
	}
}
