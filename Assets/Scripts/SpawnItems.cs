using UnityEngine;
using System.Collections;

public class SpawnItems : MonoBehaviour {
	public float spawnCD;
	public float offset;
	private float nextSpawn;
	private int childIndex;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		nextSpawn = Time.time + 5f;		//Delay before starting to spawn
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(Time.time > nextSpawn){
			childIndex = Random.Range (0, transform.childCount);
			transform.GetChild(childIndex).GetComponent<DropItems>().dropItem();
			nextSpawn = Time.time + spawnCD + Random.Range (-offset, offset);
		}
	}

}
