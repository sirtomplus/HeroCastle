using UnityEngine;
using System.Collections;

//Final boss door
//Checks if all bosses have been beaten before allowing the player in
public class BossDoor : Door {
	public TimedText LockedText;

	void Awake(){
		LockedText = gameObject.GetComponentInChildren<TimedText>();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			Inventory inventory = col.gameObject.GetComponent<Inventory>();
			bool allKilled = true;
			for(int i = 0; i < 4; ++i){
				if(!inventory.getBossesKilled(i)){
					allKilled = false;
					break;
				}
			}
			if(allKilled){
				Application.LoadLevel(level);
			}
			else{
				LockedText.Fadein();
			}

		}
	}
}
