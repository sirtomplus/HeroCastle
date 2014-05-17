using UnityEngine;
using System.Collections;

public class Knight : Enemy {
	public Rigidbody2D boomerang;
	public GameObject _tripleShot;
	public GameObject _doubleShot;
	public float boomerangSpeed;
	private Transform _shield;
	private DropItems _dropItems;

	void Awake(){
		_shield = transform.FindChild("Shield");
		_dropItems = transform.root.GetComponent<DropItems>();
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
	}

	// Use this for initialization
	void Start () {
		act = false;
		StartCoroutine(InitialWait());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(HP <= 0){
			GameObject.Find("Door").GetComponent<Door>().collider2D.enabled = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().killBoss(3);
			GameObject.FindGameObjectWithTag("BossManager").GetComponent<BossSceneManager>().ChangeBGM();
			_dropItems.dropItem();
			Destroy(gameObject);
		}
		if(act){
			switch(Random.Range(0, 4)){
				case 0:
					StartCoroutine(ShootPattern());
					break;
				case 1:
					StartCoroutine(ShieldSlash());
					break;
				case 2:
					StartCoroutine(Charge ());
					break;
				case 3:
					StartCoroutine(TripleCharge());
					break;
			}
		}
	}

	//Wait when player enters the room before acting
	IEnumerator InitialWait(){
		yield return new WaitForSeconds(2.0f);
		act = true;
	}

	IEnumerator LookAtPlayer(){
		yield return new WaitForSeconds(1.0f);
		FacePlayer();
		yield return new WaitForSeconds(1.0f);
		act = true;
	}

	IEnumerator ShootPattern(){
		act = false;
		renderer.material.color = Color.magenta;
		yield return new WaitForSeconds(1.0f);
		renderer.material.color = Color.blue;
		GameObject _triShot = Instantiate(_tripleShot, transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
		if(facingRight){
			_triShot.transform.Rotate(new Vector3(0f, 0f, -140f));
		}
		yield return new WaitForSeconds(0.7f);
		GameObject _doubShot = Instantiate(_doubleShot, transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
		if(facingRight){
			_doubShot.transform.Rotate(new Vector3(0f, 0f, -140f));
		}
		yield return new WaitForSeconds(0.7f);

		GameObject _triShot2 = Instantiate(_tripleShot, transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
		if(facingRight){
			_triShot2.transform.Rotate(new Vector3(0f, 0f, -140f));
		}
		StartCoroutine(LookAtPlayer());
	}

	IEnumerator ShieldSlash(){
		act = false;
		renderer.material.color = Color.green;
		yield return new WaitForSeconds(1.0f);
		renderer.material.color = Color.blue;
		DisableShield();
		ThrowShield();

		//Wait for shield to return
		yield return new WaitForSeconds(0.5f);
		StartCoroutine(LookAtPlayer());
	}

	IEnumerator Charge(){
		act = false;
		renderer.material.color = Color.gray;
		yield return new WaitForSeconds(1.0f);
		renderer.material.color = Color.blue;
		if(facingRight){
			rigidbody2D.AddForce(new Vector2(moveForce, 0f));
		}
		else{
			rigidbody2D.AddForce(new Vector2(-moveForce, 0f));
		}
		StartCoroutine(LookAtPlayer());
	}

	IEnumerator TripleCharge(){
		act = false;
		for(int i = 0; i < 3; ++i){
			renderer.material.color = Color.gray;
			yield return new WaitForSeconds(0.7f);
			renderer.material.color = Color.blue;
			if(facingRight){
				rigidbody2D.AddForce(new Vector2(moveForce, 0f));
			}
			else{
				rigidbody2D.AddForce(new Vector2(-moveForce, 0f));
			}
			yield return new WaitForSeconds(0.5f);
			FacePlayer();
		}
		StartCoroutine(LookAtPlayer());
	}

	void ThrowShield(){
		Rigidbody2D shieldSlash = Instantiate(boomerang, transform.position, Quaternion.Euler(0f, 0f, 0f)) as Rigidbody2D;
		if(facingRight){
			shieldSlash.velocity = new Vector2(boomerangSpeed, 0f);
		}
		else{
			shieldSlash.velocity = new Vector2(-boomerangSpeed, 0f);
		}
		shieldSlash.GetComponent<Boomerang>().parentEnemy = this;
	}

	void DisableShield(){
		_shield.collider2D.enabled = false;
		_shield.renderer.enabled = false;
	}

	public void EnableShield(){
		_shield.collider2D.enabled = true;
		_shield.renderer.enabled = true;
	}
}
