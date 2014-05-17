using UnityEngine;
using System.Collections;

//Loads the game data
//Manages the location of the player
//Responsible for respawning the player after death
public class GameMaster : MonoBehaviour {
	public GameObject Player;
	public GameObject Bars;
	public string currentScene;
	public string lastScene;
	public GameObject spawnLocation;
	public Transform _player;

	public string nextSpawnLocation;
	public string previousSpawnLocation;
	[HideInInspector]
	public SaveManager _saveManager;
	[HideInInspector]
	public int savedHP;
	[HideInInspector]
	public int savedMP;
	[HideInInspector]
	public bool restart = false;

	void Awake(){
		DontDestroyOnLoad(this);
		_saveManager = transform.root.GetComponent<SaveManager>();
		Instantiate(Bars, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
		Rigidbody2D player = Instantiate(Player, new Vector3(-50f,50f,0f), Quaternion.Euler(0f,0f,0f)) as Rigidbody2D;
	}
	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		_saveManager.Load();

		DontDestroyOnLoad(_player);
		if(PlayerPrefs.GetInt("Health", 100) < 70){
			_player.GetComponent<PlayerHealth>().health = 70;
		}
		else{
			_player.GetComponent<PlayerHealth>().health = PlayerPrefs.GetInt("Health", 100);
		}

		if(PlayerPrefs.GetInt("MP", 100) < 70){
			_player.GetComponent<PlayerHealth>().MP = 70;
		}
		else{
			_player.GetComponent<PlayerHealth>().MP = PlayerPrefs.GetInt("MP", 100);
		}
		for(int i = 0; i < 2; ++i){
			if(_player.GetComponent<Inventory>().getHPBoost(i)){
				_player.GetComponent<PlayerHealth>().maxHealth += 25;
				_player.GetComponent<PlayerHealth>().UpdateMaxHealthBar();
			}
			if(_player.GetComponent<Inventory>().getMPBoost(i)){
				_player.GetComponent<PlayerHealth>().maxMP += 50;
				_player.GetComponent<PlayerHealth>().UpdateMaxMPBar();
			}
		}
		if(_player.GetComponent<Inventory>().getHPBoost(2)){
			_player.GetComponent<PlayerHealth>().maxHealth += 50;
			_player.GetComponent<PlayerHealth>().UpdateMaxHealthBar();
			_player.GetComponent<PlayerHealth>().UpdateMaxHealthBar();
		}
		_player.GetComponent<PlayerHealth>().UpdateHealthBar();
		_player.GetComponent<PlayerHealth>().UpdateMPBar();
		savedHP = _player.GetComponent<PlayerHealth>().health;
		savedMP = _player.GetComponent<PlayerHealth>().MP;
		lastScene = _saveManager.getSavedLevel();
		nextSpawnLocation = _saveManager.getSpawnLocation();
		Application.LoadLevel(lastScene);

	}
	
	// Update is called once per frame
	void Update () {
		currentScene = Application.loadedLevelName;
		if(currentScene != lastScene){
			lastScene = currentScene;
			restart = true;
		}
		if(Input.GetButtonDown("Start") && _player.GetComponent<PlayerController>().isDead){

			Application.LoadLevel(lastScene);
			revivePlayer();
			restart = true;
		}
	}



	void LateUpdate(){
		if(restart){
			StartCoroutine(newScene());
			restart = false;
		}
	}

	public void killPlayer(){
		_player = null;
	}

	public void checkPoint(){
		savedHP = _player.GetComponent<PlayerHealth>().health;
		savedMP = _player.GetComponent<PlayerHealth>().MP;
	}

	public void revivePlayer(){
		_player.GetComponent<PlayerController>().nextPause = Time.time + 0.1f;
		if(savedHP < 70){
			_player.GetComponent<PlayerHealth>().health = 70;
		}
		else{
			_player.GetComponent<PlayerHealth>().health = savedHP;
		}
		if(savedMP < 70){
			_player.GetComponent<PlayerHealth>().MP = 70;
		}
		else{
			_player.GetComponent<PlayerHealth>().MP = savedMP;
		}
		_player.GetComponent<PlayerController>().isActing = false;
		_player.GetComponent<PlayerController>().isDead = false;
		_player.GetComponent<PlayerHealth>().UpdateHealthBar();
		_player.GetComponent<PlayerHealth>().UpdateMPBar();

//		_player.gameObject.layer = 9;
		StartCoroutine(WaittoAllowPlayertoTakeHits());
	}


	public void moveToLocation(GameObject spawnLocation){
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().setPosition(spawnLocation.transform.position);
		_player.transform.position = spawnLocation.transform.position;
	}

	public IEnumerator findSpawnLocation(){
		yield return new WaitForFixedUpdate();
		spawnLocation = GameObject.Find("FrontDoorSpawn");
	}

	public IEnumerator newScene(){
		yield return new WaitForSeconds(0.2f);
		spawnLocation = GameObject.Find (nextSpawnLocation);
		moveToLocation(spawnLocation);
		lastScene = currentScene;
	}

	public void Checkpoint(string spawnpoint){
		nextSpawnLocation = spawnpoint;
		savedHP = _player.GetComponent<PlayerHealth>().health;
		savedMP = _player.GetComponent<PlayerHealth>().MP;
		lastScene = currentScene;
	}

	public string SpawnLocation(){
		return nextSpawnLocation;
	}

	IEnumerator WaittoAllowPlayertoTakeHits(){
		_player.gameObject.layer = 0;
		yield return new WaitForSeconds(1.0f);
		_player.gameObject.layer = 9;
	}
}
