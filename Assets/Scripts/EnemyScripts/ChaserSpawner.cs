using UnityEngine;
using System.Collections;

public class ChaserSpawner : Spawner {
	public float timeBetweenSpawns;
	public float distanceToSpawn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(distance () < distanceToSpawn){
			isActive = true;
		}
		else{
			isActive = false;
		}
		if(isActive && Time.time > getNextSpawn()){
//			Rigidbody2D spawnedEnemy = Instantiate(enemy, 
//			                                       new Vector3(transform.position.x + Random.Range(-spawnOffsetX, spawnOffsetX), transform.position.y + Random.Range(-spawnOffsetY, spawnOffsetY), 0f), 
//			                                       Quaternion.Euler(new Vector3(0f, 0f, 0f))) as Rigidbody2D;
			StartCoroutine(DoubleSpawn());
			setNextSpawn();
		}
	}

	IEnumerator DoubleSpawn(){
		Instantiate(enemy, new Vector3(transform.position.x + Random.Range(-spawnOffsetX, spawnOffsetX), transform.position.y + Random.Range(-spawnOffsetY, spawnOffsetY), 0f), 
		                   Quaternion.Euler(new Vector3(0f, 0f, 0f)));
		yield return new WaitForSeconds(timeBetweenSpawns);
		Instantiate(enemy, new Vector3(transform.position.x + Random.Range(-spawnOffsetX, spawnOffsetX), transform.position.y + Random.Range(-spawnOffsetY, spawnOffsetY), 0f), 
		                   Quaternion.Euler(new Vector3(0f, 0f, 0f)));

	}
}
