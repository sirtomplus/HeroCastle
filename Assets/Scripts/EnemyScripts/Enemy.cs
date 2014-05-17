using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float moveSpeed;
	public float jumpForce = 400f;
	public float moveForce = 150f;
	public int HP;
	public AudioClip hitSFX;

	[HideInInspector]
	public bool dead = false;
	public bool act = false;
	public bool facingRight = true;
	private float invincibleTime = 0.15f;
	private bool isInvincible = false;

	[HideInInspector]
	public float nextFlip;

	private DropItems itemDrop;
	[HideInInspector]
	public Volume _volume;

	void Awake () {
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
		initItems();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		if(HP <= 0 && !dead){
			itemDrop.dropItem();
			Destroy (gameObject);
		}
		if(act){
			rigidbody2D.velocity = new Vector2(transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);
		}
	}

	public void dropItems(){
		itemDrop.dropItem();
	}

	public void initItems(){
		itemDrop = transform.root.GetComponent<DropItems>();
	}

	public void StopAct(){
		act = false;
		rigidbody2D.velocity = new Vector2(0,0);
	}

	public void Hurt(int damage){
		if(!isInvincible){
			AudioSource.PlayClipAtPoint(hitSFX, transform.position, _volume.SFXVol);
			HP -= damage;
		}
	}

	IEnumerator InvincibleWait(){
		isInvincible = true;
		yield return new WaitForSeconds(invincibleTime);
		isInvincible = false;
	}

	public void Flip(){
		facingRight = !facingRight;
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}

	public void Jump(){
		rigidbody2D.AddForce(new Vector2(0, jumpForce));
	}

	public void stepRight(){
		rigidbody2D.AddForce(new Vector2(moveForce, 0));
	}

	public void stepLeft(){
		rigidbody2D.AddForce(new Vector2(-moveForce, 0));
	}

	public void FacePlayer(){
		GameObject _player = GameObject.FindGameObjectWithTag ("Player");
		if(_player != null){
			if(_player.transform.position.x - transform.position.x < 0 && facingRight){
				Flip ();
			}
			else if(_player.transform.position.x - transform.position.x > 0 && !facingRight){
				Flip();
			}
		}
	}
}
