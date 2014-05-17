using UnityEngine;
using System.Collections;

public class SaveManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Save(){
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt("SaveData", 1);
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Inventory _inventory = player.GetComponent<Inventory>();
		Volume _volume = GameObject.Find ("Volume").GetComponent<Volume>();
		PlayerPrefs.SetFloat("BGMVol", _volume.BGMVol);
		PlayerPrefs.SetFloat("SFXVol", _volume.SFXVol);
		PlayerPrefs.SetString("SavedLevel", Application.loadedLevelName);
		PlayerPrefs.SetInt("Health", player.GetComponent<PlayerHealth>().health);
		PlayerPrefs.SetInt("MP", player.GetComponent<PlayerHealth>().MP);
		Debug.Log(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>().SpawnLocation());
		setSpawnLocation(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>().SpawnLocation());
		if(_inventory.GetDJump()){
			PlayerPrefs.SetInt("DoubleJump", 1);
		}
		if(_inventory.GetKey(0)){
			PlayerPrefs.SetInt("Key0", 1);
		}
		if(_inventory.GetKey(1)){
			PlayerPrefs.SetInt("Key1", 1);
		}
		if(_inventory.GetKey(2)){
			PlayerPrefs.SetInt("Key2", 1);
		}
		if(_inventory.GetFireBottle()){
			PlayerPrefs.SetInt("FireBottle", 1);
		}
		if(_inventory.GetKnives()){
			PlayerPrefs.SetInt("FanOfKnives", 1);
		}
		if(_inventory.getBossesKilled(0)){
			PlayerPrefs.SetInt("Priest", 1);
		}
		if(_inventory.getBossesKilled(1)){
			PlayerPrefs.SetInt("Mage", 1);
		}
		if(_inventory.getBossesKilled(2)){
			PlayerPrefs.SetInt("Thief", 1);
		}
		if(_inventory.getBossesKilled(3)){
			PlayerPrefs.SetInt("Knight", 1);
		}
		if(_inventory.getHPBoost(0)){
			PlayerPrefs.SetInt("HPBoost0", 1);
		}
		if(_inventory.getHPBoost(1)){
			PlayerPrefs.SetInt("HPBoost1", 1);
		}
		if(_inventory.getHPBoost(2)){
			PlayerPrefs.SetInt("HPBoost2", 1);
		}
		if(_inventory.getMPBoost(0)){
			PlayerPrefs.SetInt("MPBoost0", 1);
		}
		if(_inventory.getMPBoost(1)){
			PlayerPrefs.SetInt("MPBoost1", 1);
		}
	}

	public void Load(){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		player.GetComponent<PlayerController>().enabled = true;
		player.GetComponent<PlayerHealth>().health = PlayerPrefs.GetInt("Health", 100);
		player.GetComponent<PlayerHealth>().MP = PlayerPrefs.GetInt("MP", 100);
		if(getDoubleJump() == 1){
//			player.GetComponent<DoubleJump>().enableDJump();
			player.GetComponent<Inventory>().PickUpDoubleJump();
		}
		if(PlayerPrefs.GetInt("Key0", 0) == 1){
			player.GetComponent<Inventory>().PickUpKey(0);
		}
		if(PlayerPrefs.GetInt("Key1", 0) == 1){
			player.GetComponent<Inventory>().PickUpKey(1);
		}
		if(PlayerPrefs.GetInt("Key2", 0) == 1){
			player.GetComponent<Inventory>().PickUpKey(2);
		}
		if(PlayerPrefs.GetInt("FireBottle", 0) == 1){
			player.GetComponent<Inventory>().PickUpFireBottle();
		}
		if(PlayerPrefs.GetInt("FanOfKnives", 0) == 1){
			player.GetComponent<Inventory>().PickUpKnives();
		}
		if(PlayerPrefs.GetInt("Priest", 0) == 1){
			player.GetComponent<Inventory>().killBoss(0);
		}
		if(PlayerPrefs.GetInt("Mage", 0) == 1){
			player.GetComponent<Inventory>().killBoss(1);
		}
		if(PlayerPrefs.GetInt("Thief", 0) == 1){
			player.GetComponent<Inventory>().killBoss(2);
		}
		if(PlayerPrefs.GetInt("Knight", 0) == 1){
			player.GetComponent<Inventory>().killBoss(3);
		}
		if(PlayerPrefs.GetInt("HPBoost0", 0) == 1){
			player.GetComponent<Inventory>().PickupHPBoost(0);
		}
		if(PlayerPrefs.GetInt("HPBoost1", 0) == 1){
			player.GetComponent<Inventory>().PickupHPBoost(1);
		}
		if(PlayerPrefs.GetInt("HPBoost2", 0) == 1){
			player.GetComponent<Inventory>().PickupHPBoost(2);
		}
		if(PlayerPrefs.GetInt("MPBoost0", 0) == 1){
			player.GetComponent<Inventory>().PickupMPBoost(0);
		}
		if(PlayerPrefs.GetInt("MPBoost1", 0) == 1){
			player.GetComponent<Inventory>().PickupMPBoost(1);
		}
	}

	public void setSpawnLocation(string spawnLocation){
		PlayerPrefs.SetString ("SpawnLocation", spawnLocation);
	}

	public string getSavedLevel(){
		return PlayerPrefs.GetString("SavedLevel", "WestWing");
	}

	public void setBossKilled(string boss){
		PlayerPrefs.SetInt(boss, 1);
	}

	public string getSpawnLocation(){
		return PlayerPrefs.GetString("SpawnLocation", "FrontDoorSpawn");
	}
		
	public int getDoubleJump(){
		return PlayerPrefs.GetInt("DoubleJump", 0);
	}
}
