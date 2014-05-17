using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public string level;
	public int keyRequirement;
	public string SpawnLocation;
	void Awake(){

	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			if(keyRequirement == -1){
				GameObject.Find ("GameMaster").GetComponent<GameMaster>().nextSpawnLocation = SpawnLocation;
				Application.LoadLevel(level);
			}
			else{
				Inventory inventory = col.gameObject.GetComponent<Inventory>();
				if(inventory.GetKey (keyRequirement)){
					GameObject.Find ("GameMaster").GetComponent<GameMaster>().nextSpawnLocation = SpawnLocation;
					Application.LoadLevel(level);
				}
			}
		}
	}
}
