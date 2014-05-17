using UnityEngine;
using System.Collections;

/*Bosses
 * 0	Priest
 * 1	Mage
 * 2	Thief
 * 3	Knight
 */
public class Inventory : MonoBehaviour {
	private bool[] key = new bool[] {false, false, false};
	private bool doubleJump = false;
	private bool fireBottle = false;
	private bool fanOfKnives = false;
	private bool[] bossesKilled = new bool[] {false, false, false, false};
	private bool[] HPBoosts = new bool[] {false, false, false};
	private bool[] MPBoosts = new bool[] {false, false};

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//For deleting data or starting new game
	public void ResetAll(){
		for(int i = 0; i < 3; i++){
			key[i] = false;
			HPBoosts[i] = false;
		}
		for( int i = 0; i < 2; ++i){
			MPBoosts[i] = false;
		}
		for(int i = 0; i < 4; ++i){
			bossesKilled[i] = false;
		}
		doubleJump = false;
		fireBottle = false;
		fanOfKnives = false;
	}

	public void PickUpKey(int keyNumber){
		key[keyNumber] = true;
	}

	public bool GetKey(int keyNumber){
		return key[keyNumber];
	}

	public void PickUpDoubleJump(){
		doubleJump = true;
		transform.root.GetComponent<DoubleJump>().enableDJump();
	}

	public bool GetDJump(){
		return doubleJump;
	}

	public void PickUpFireBottle(){
		fireBottle = true;
		transform.root.FindChild("FireBottleGun").GetComponent<FireBottleGun>().enableFireBottle();
	}

	public bool GetFireBottle(){
		return fireBottle;
	}

	public void PickUpKnives(){
		fanOfKnives = true;
		transform.root.FindChild("FanOfKnivesGun").GetComponent<FanOfKnives>().enableFanOfKnives();
	}

	public bool GetKnives(){
		return fanOfKnives;
	}

	public void killBoss(int bossNum){
		bossesKilled[bossNum] = true;
	}

	public bool getBossesKilled(int bossNum){
		return bossesKilled[bossNum];
	}

	public void PickupHPBoost(int boostNum){
		HPBoosts[boostNum] = true;
	}

	public bool getHPBoost(int boostNum){
		return HPBoosts[boostNum];
	}

	public void PickupMPBoost(int boostNum){
		MPBoosts[boostNum] = true;
	}

	public bool getMPBoost(int boostNum){
		return MPBoosts[boostNum];
	}
}
