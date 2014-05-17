using UnityEngine;
using System.Collections;

public class DusaSpawner : Spawner {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(distance () < 25){
			isActive = true;
		}
		else{
			isActive = false;
		}
		if(isActive && Time.time > getNextSpawn()){
			Instantiate(enemy, new Vector3(transform.position.x + spawnOffsetX, transform.position.y + Random.Range(-spawnOffsetY, spawnOffsetY), 0f), 
			                                       Quaternion.Euler(new Vector3(0f, 0f, 0f)));
			setNextSpawn();
		}
	}
}
