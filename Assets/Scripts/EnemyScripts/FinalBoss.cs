using UnityEngine;
using System.Collections;

//Add in movements to points of stage
//Randomize actions

public class FinalBoss : Enemy {
	private Transform _target;
	public Rigidbody2D homingProjectile;
	public Rigidbody2D Chaser;
	public Rigidbody2D bigProjectile;
	public GameObject quadProjectile;
	public float bigProjSpeed;
	private float streamGap = 0.1f;

	private Transform _leftPos;
	private Transform _centerPos;
	private Transform _rightPos;
	private Transform _flyPos;
	private int position;

	void Awake () {
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
		_target = GameObject.FindGameObjectWithTag("Player").transform;
		_leftPos = GameObject.Find ("LeftPos").transform;
		_centerPos = GameObject.Find ("CenterPos").transform;
		_rightPos = GameObject.Find ("RightPos").transform;
		_flyPos = GameObject.Find ("FlyPos").transform;
		initItems();
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(HP <= 0){
			Destroy(gameObject);
		}
		if(act){
			switch(Random.Range (0, 6)){
				case 0:StartCoroutine(Teleport());break;
				case 1:StartCoroutine(Spray ());break;
				case 2:StartCoroutine(Stream ());break;
				case 3:StartCoroutine(Flower ());break;
				case 4:StartCoroutine(SpawnChaser());break;
				case 5:StartCoroutine(ShootBig());break;
			}
		}
	}

	void moveToPosition(int index){
		switch(index){
			case 0:transform.position = _leftPos.position;position = 0;break;
			case 1:transform.position = _centerPos.position;position = 1;break;
			case 2:transform.position = _rightPos.position;position = 2;break;
			case 3:transform.position = _flyPos.position;position = 1;break;
		}
	}

	IEnumerator Teleport(){
		act = false;
		renderer.material.color = Color.white;		//to indicate action (remove later)
		yield return new WaitForSeconds(1.5f);
		renderer.material.color = Color.blue;		//to indicate action (remove later)
		int destination = Random.Range (0, 4);
		if(destination == position){
			destination = (destination+1)%4;
		}
		moveToPosition(Random.Range (0, 4));
		yield return new WaitForSeconds(2.0f);
		FacePlayer();
		act = true;
	}

	IEnumerator Spray(){
		act = false;
		renderer.material.color = Color.magenta;
		yield return new WaitForSeconds(1.0f);
		switch(Random.Range (0, 2)){
			case 0:moveToPosition(0);break;
			case 1:moveToPosition(2);break;
		}
		FacePlayer();
		yield return new WaitForSeconds(1.75f);
		renderer.material.color = Color.blue;

		for(int i = 0; i < 8; ++i){
			Rigidbody2D bullet = Instantiate(homingProjectile, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 0f))) as Rigidbody2D;
			if(!facingRight){
				bullet.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0, 20f)+80f));
			}
			else{
				bullet.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0, 20f)-100f));
			}
			yield return new WaitForSeconds(0.15f);
		}

		//Delay before making another action
		yield return new WaitForSeconds(3.0f);
		act = true;
	}

	IEnumerator Stream(){
		act = false;
		renderer.material.color = Color.green;		//to indicate action (remove later)
		yield return new WaitForSeconds(1.0f);
		rigidbody2D.gravityScale = 0;
		moveToPosition(3);
		FacePlayer();
		yield return new WaitForSeconds(1.5f);
		renderer.material.color = Color.blue;		//to indicate action (remove later)
		if(facingRight){
			for(int i = 0; i < 180; ++i){
				GameObject quadProj = Instantiate(quadProjectile, transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
				quadProj.transform.Rotate(new Vector3(0f, 0f, i*2));
				yield return new WaitForSeconds(streamGap);
			}
		}
		else{
			for(int i = 0; i < 180; ++i){
				GameObject quadProj = Instantiate(quadProjectile, transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
				quadProj.transform.Rotate(new Vector3(0f, 0f, -i*2));
				yield return new WaitForSeconds(streamGap);
			}
		}
		yield return new WaitForSeconds(1.0f);
		rigidbody2D.gravityScale = 1;

		//Delay before making another action
		yield return new WaitForSeconds(5.0f);
		act = true;
	}

	IEnumerator SpawnChaser(){
		act = false;
		renderer.material.color = Color.gray;
		yield return new WaitForSeconds(1.0f);
		Instantiate(Chaser, new Vector3(transform.position.x, transform.position.y + 5f), Quaternion.Euler(0f, 0f, 0f));
		yield return new WaitForSeconds(5.0f);
		act = true;
	}

	IEnumerator ShootBig(){
		act = false;
		renderer.material.color = Color.yellow;		//to indicate action (remove later)
		yield return new WaitForSeconds(1.5f);
		renderer.material.color = Color.blue;		//to indicate action (remove later)

		switch(Random.Range (0, 2)){
			case 0:moveToPosition(0);break;
			case 1:moveToPosition(2);break;
		}
		FacePlayer();
		yield return new WaitForSeconds(1.0f);
		Rigidbody2D bullet = Instantiate(bigProjectile, transform.position, Quaternion.Euler(0f, 0f, 0f)) as Rigidbody2D;
		if(facingRight){
			bullet.velocity = new Vector3(bigProjSpeed, 0f, 0f);
		}
		else{
			bullet.velocity = new Vector3(-bigProjSpeed, 0f, 0f);
		}
		yield return new WaitForSeconds(4.0f);
		act = true;
	}

	IEnumerator Flower(){
		act = false;
		renderer.material.color = Color.cyan;		//to indicate action (remove later)
		yield return new WaitForSeconds(1.0f);
		rigidbody2D.gravityScale = 0;
		moveToPosition(3);
		yield return new WaitForSeconds(1.5f);
		renderer.material.color = Color.blue;		//to indicate action (remove later)
		for(int i = 0; i < 12; ++i){
			for(int j = 0; j < 12; ++j){
				Rigidbody2D bullet = Instantiate(homingProjectile, transform.position, Quaternion.Euler(0f, 0f, 0f)) as Rigidbody2D;
				bullet.GetComponent<HomingBullet>().speed = 4f;
				bullet.transform.Rotate(0f, 0f, Random.Range (15, 40)*j);
			}
			yield return new WaitForSeconds(0.75f);
		}
		yield return new WaitForSeconds(1.0f);
		rigidbody2D.gravityScale = 1;
		yield return new WaitForSeconds(5.0f);
		act = true;
	}
}
