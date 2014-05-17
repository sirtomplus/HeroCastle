using UnityEngine;
using System.Collections;

public class MageRainSpawner : MonoBehaviour {
	public Rigidbody2D projectile;
	public float offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn(){
		Instantiate(projectile,
		            new Vector3(transform.position.x + Random.Range(-offset, offset), transform.position.y, transform.position.z),
		            Quaternion.Euler(0f, 0f, 0f));
	}
}
