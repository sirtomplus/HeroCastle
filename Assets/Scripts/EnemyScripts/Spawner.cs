using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public Rigidbody2D enemy;
	public float spawnOffsetX;
	public float spawnOffsetY;
	public float spawnCD;
	private float nextSpawn;
	public bool isActive;

	// Use this for initialization
	void Start () {
		nextSpawn = Time.time + spawnCD;
	}

	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(distance () < 20){
			isActive = true;
		}
		else{
			isActive = false;
		}
		if(isActive && Time.time > nextSpawn){
			Instantiate(enemy, 
			            new Vector3(transform.position.x + Random.Range (-spawnOffsetX, spawnOffsetX), transform.position.y + Random.Range(-spawnOffsetY, spawnOffsetY), 0f), 
			            Quaternion.Euler(new Vector3(0f, 0f, 0f)));
			setNextSpawn();
		}
	}

	public void makeActive(){
		isActive = true;
	}

	public float distance(){
		if(GameObject.FindWithTag("Player").transform != null){
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			return Mathf.Sqrt((player.position.x - transform.position.x)*(player.position.x - transform.position.x) - (player.position.y - transform.position.y)*(player.position.y - transform.position.y));
		}
		return 100f;
	}

	public void setNextSpawn(){
		nextSpawn = Time.time + spawnCD;
	}

	public float getNextSpawn(){
		return nextSpawn;
	}
}
