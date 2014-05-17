using UnityEngine;
using System.Collections;

public class MageRainSpawnerParent : MonoBehaviour {
	public GameObject[] mageRainSpawners;

	void Awake(){
//		mageRainSpawners = GameObject.FindGameObjectsWithTag("Spawner");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Rain(){
		foreach(GameObject m in mageRainSpawners){
			m.GetComponent<MageRainSpawner>().Spawn();
		}
	}
}
