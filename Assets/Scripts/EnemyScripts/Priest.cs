using UnityEngine;
using System.Collections;

public class Priest : Enemy{
	private Transform Child1;
	private Transform Child2;

	public bool phase2 = false;

	public bool invulnerable;
	public int healAmt = 10;
	public int MP = 100;
	public int MPCost = 5;

	private int childsMaxHP;
	private DropItems _dropItems;

	void Awake(){
		Child1 = transform.FindChild("Child1");
		Child2 = transform.FindChild("Child2");
		_dropItems = transform.root.GetComponent<DropItems>();
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
	}

	void Start(){
		invulnerable = true;
		childsMaxHP = Child1.GetComponent<Charger>().HP;
	}

	// Update is called once per frame
	void Update () {
	
	}



	void FixedUpdate(){
		if(HP <= 0){
			GameObject.Find("Door").GetComponent<Door>().collider2D.enabled = true;
//			GameObject.FindGameObjectWithTag("GameController").GetComponent<SaveManager>().setBossKilled("Priest");
			GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().killBoss(0);
			GameObject.FindGameObjectWithTag("BossManager").GetComponent<BossSceneManager>().ChangeBGM();
			_dropItems.dropItem();
			Destroy(gameObject);
		}
		if(MP >= MPCost && Child1.GetComponent<Charger>().HP + 10 <= childsMaxHP){
			Heal ();
			StartCoroutine(ChangeColor());
		}
		else if(MP < MPCost && !phase2){
			Debug.Log("phase2");
			phase2 = true;
			Child2.FindChild ("ShowerGun").GetComponent<MakeItRain>().enableShower();
		}
	}


	void Heal(){
		Child1.GetComponent<Charger>().HP += healAmt;
		MP -= MPCost;
	}

	IEnumerator ChangeColor(){
		Child1.renderer.material.color = Color.white;
		yield return new WaitForSeconds(1.0f);
		Child1.renderer.material.color = Color.blue;
	}
}
