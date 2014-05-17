using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int health = 100;
	public int maxHealth = 100;
	public int MP = 100;
	public int maxMP = 100;
	public float invincTime = 1.0f;		//invincibility after taking a hit
	public float hurtForce = 10f;

	private PlayerController playerCtrl;

	private SpriteRenderer healthBar;
	private Vector3 healthScale;
	private SpriteRenderer healthOutline;
	private Vector3 healthOutlineScale;
	private SpriteRenderer MPBar;
	private Vector3 MPScale;
	private SpriteRenderer MPOutline;
	private Vector3 MPOutlineScale;
//	private SpriteRenderer playerSprite;

	public AudioClip HitSound;
	public AudioClip HealthPickupSound;


	void Awake () {
		playerCtrl = GetComponent<PlayerController>();
		healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
		healthScale = healthBar.transform.localScale;
		MPBar = GameObject.Find ("MPBar").GetComponent<SpriteRenderer>();
		MPScale = MPBar.transform.localScale;
		healthOutline = GameObject.Find ("HealthOutline").GetComponent<SpriteRenderer>();
		healthOutlineScale = healthOutline.transform.localScale;
		MPOutline = GameObject.Find ("MPOutline").GetComponent<SpriteRenderer>();
		MPOutlineScale = MPOutline.transform.localScale;
//		playerSprite = transform.FindChild("PlayerSprite").GetComponent<SpriteRenderer>();
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	

	void OnCollisionEnter2D ( Collision2D col ) {
		if( col.gameObject.tag == "EnemyHitBox" || col.gameObject.tag == "Enemy" && !playerCtrl.isDead) {
			TakeDamage( col.transform, col.gameObject.GetComponent<EnemyDamage>().damage );

			gameObject.layer = 0;
			if(health <= 0){
				playerCtrl.isDead = true;
				playerCtrl.isActing = true;
				GameObject _gameOver = GameObject.FindGameObjectWithTag("GameOver");
				_gameOver.GetComponent<GameOver>().Fade();
				rigidbody2D.velocity = new Vector2(0f, 0f);
			}
			else{
				StartCoroutine(BlinkUnit (invincTime, 5));
				StartCoroutine(HitStun());
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Enemy" || col.tag == "EnemyHitBox" || col.tag == "EnemyBullet" && !playerCtrl.isDead){
			gameObject.layer = 0;
			TakeDamage(col.transform, col.gameObject.GetComponent<EnemyDamage>().damage);

			if(health <= 0){
				playerCtrl.isDead = true;
				playerCtrl.isActing = true;
				GameObject _gameOver = GameObject.FindGameObjectWithTag("GameOver");
				_gameOver.GetComponent<GameOver>().Fade();
				rigidbody2D.velocity = new Vector2(0f, 0f);
			}
			else{
				StartCoroutine(BlinkUnit (invincTime, 5));
				StartCoroutine(HitStun());
			}
		}
	}

	IEnumerator BlinkUnit(float blinkTime, int blinks) {
		float endTime = Time.time + blinkTime;
		
		while (Time.time < endTime) {
			yield return new WaitForSeconds(blinkTime/2/blinks);
//			renderer.enabled = !renderer.enabled;	// blink unit
//			playerSprite.enabled = !playerSprite.enabled;
		}
		
		// when done blinking make sure unit is shown
//		renderer.enabled = true;
//		playerSprite.enabled = true;
		gameObject.layer = 9;
	}

	IEnumerator HitStun(){
		playerCtrl.isActing = true;
		playerCtrl.canMove = false;
		yield return new WaitForSeconds(0.5f);
		playerCtrl.isActing = false;
		playerCtrl.canMove = true;
	}

//Knockback feels awkward
	public void TakeDamage ( Transform enemy, int damage ) {
		playerCtrl.jump = false;
		Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 2.5f;
		if(hurtVector.x < 0){
			hurtVector += Vector3.left*5f;
		}
		else{
			hurtVector += Vector3.right*5f;
		}
		rigidbody2D.velocity = new Vector2(0f, 0f);
		rigidbody2D.AddForce(new Vector2(hurtVector.x * hurtForce, hurtVector.y*hurtForce/2));
		health -= damage;
		if(health < 0){
			health = 0;
		}
		AudioSource.PlayClipAtPoint(HitSound, transform.position, playerCtrl._volume.SFXVol);
		UpdateHealthBar();
	}

	public void Heal(int healAmount){
		health += healAmount;
		if(health > maxHealth){
			health = maxHealth;
		}
		AudioSource.PlayClipAtPoint(HealthPickupSound, transform.position, playerCtrl._volume.SFXVol);
		UpdateHealthBar();
	}

	public void RestoreMP(int Amount){
		MP += Amount;
		if(MP > maxMP){
			MP = maxMP;
		}
		AudioSource.PlayClipAtPoint(HealthPickupSound, transform.position, playerCtrl._volume.SFXVol);
		UpdateMPBar();
	}

	public void UseMP(int Amount){
		MP -= Amount;
		if(MP < 0){
			MP = 0;
		}
		UpdateMPBar();
	}

	public void UpdateHealthBar(){
		healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);
	}

	public void UpdateMPBar(){
		MPBar.transform.localScale = new Vector3(MPScale.x * MP * 0.01f, 1, 1);
	}

	public void UpdateMaxHealthBar(){
		healthOutline.transform.localPosition = new Vector3(healthOutline.transform.localPosition.x + 0.21f, 0f, 0f);
		healthOutline.transform.localScale = new Vector3(healthOutlineScale.x * maxHealth * 0.01f, 1, 1);
	}

	public void UpdateMaxMPBar(){
		MPOutline.transform.localPosition = new Vector3(MPOutline.transform.localPosition.x + 0.42f, 0f, 0f);
		MPOutline.transform.localScale = new Vector3(MPOutlineScale.x * maxMP * 0.01f, 1, 1);
	}

	public void FindBars(){
		healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
		healthScale = healthBar.transform.localScale;
		MPBar = GameObject.Find ("MPBar").GetComponent<SpriteRenderer>();
		MPScale = MPBar.transform.localScale;
	}
}
