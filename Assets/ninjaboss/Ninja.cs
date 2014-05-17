using UnityEngine;
using System.Collections;

public class Ninja : Enemy {

	public GameObject _kunai;
	public GameObject _tripleKunai;
	public GameObject _powerWave;
	public bool grounded = true;
	public float kunaiRotation;
	public float kunaiOffset;
	private Transform player;

	private Transform ninja;
	private float time;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(InitialWait());
		FacePlayer();
		grounded = true;
		ninja = GetComponent<Transform>();
		player = GameObject.FindGameObjectWithTag("Player").transform;

	}

	
	// Update is called once per frame
	void Update () 
	{

	}

	void FixedUpdate()
	{
		if(HP <= 0)
		{
			Destroy(gameObject);
		}
		if(act)
		{
			switch(Random.Range (0, 5))
			{
			case 0:StartCoroutine(PowerWave ());break;
			case 1:StartCoroutine(NinjaAttack());break;
			case 2:StartCoroutine(JumpToss ());break;
			case 3:StartCoroutine (RunLeft());break;
			case 4:StartCoroutine(RunRight ());break;
			}
		}
	}

	IEnumerator InitialWait(){
		act = false;
		yield return new WaitForSeconds(2.0f);
		act = true;
	}

	IEnumerator PowerWave()
	{
		act = false;
		FacePlayer ();
		
		if(facingRight)
		{
			for (int i = 0; i < 3; i++)
			{
			GameObject pWaveRight = Instantiate(_powerWave, transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
				yield return new WaitForSeconds(1.0f);
			}
		}
		else
		{
			for (int i = 0; i < 3; i++)
			{
				GameObject pWaveLeft = Instantiate(_powerWave, transform.position, Quaternion.Euler(0f, 0f, -180f)) as GameObject;
				yield return new WaitForSeconds(1.0f);
			}
		}
		yield return new WaitForSeconds(2.0f);
		act = true;
	}
	
	IEnumerator NinjaAttack()
	{
		act = false;
		Kawarimi ();

		rigidbody2D.gravityScale = 2f;

		yield return new WaitForSeconds (1.1f);

		GameObject pWaveLeft = Instantiate(_powerWave, transform.position, Quaternion.Euler(0f, 0f, -180f)) as GameObject;
		GameObject pWaveRight = Instantiate(_powerWave, transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
		FacePlayer ();

		yield return new WaitForSeconds(1.0f);

		rigidbody2D.gravityScale = 1f;
		act = true;
	}

	IEnumerator JumpToss()
	{
		act = false;
		int index = 0;
		FacePlayer ();
		float temp = kunaiRotation;

		if (grounded)
		{
			Jump();
			grounded = false;
		}
		yield return new WaitForSeconds(1.0f);

		rigidbody2D.isKinematic = true;
		if (facingRight)
		{
			while (rigidbody2D.isKinematic && index < 3)
			{
				GameObject tripleKunaiThrow = Instantiate
					(_tripleKunai, transform.position, Quaternion.Euler (0f, 0f, -kunaiRotation)) as GameObject;
				kunaiRotation -= kunaiOffset;
				yield return new WaitForSeconds(1.0f);
				
				index++;
			}
			rigidbody2D.isKinematic = false;
			grounded = true;
		}
		else
		{
			while (rigidbody2D.isKinematic && index < 3)
			{
				GameObject tripleKunaiThrow = Instantiate
					(_tripleKunai, transform.position, Quaternion.Euler (0f, 0f, kunaiRotation)) as GameObject;
				kunaiRotation += kunaiOffset;
				yield return new WaitForSeconds(1.0f);
				
				index++;
			}
			rigidbody2D.isKinematic = false;
			grounded = true;
		}

		kunaiRotation = temp;
		yield return new WaitForSeconds(2.0f);
		act = true;
	}

//	IEnumerator Movement()
//	{
//
//	}


	IEnumerator RunLeft()
	{
		act = false;

		rigidbody2D.AddForce(new Vector2(-moveForce, 0));
		yield return new WaitForSeconds(1.0f);

		act = true;
	}
	IEnumerator RunRight()
	{
		act = false;
		
		rigidbody2D.AddForce(new Vector2(moveForce, 0));
		yield return new WaitForSeconds(1.0f);
		
		act = true;
	}
	void Kawarimi()
	{
		//		Stand and wait
		//		if enemy takes damage during this state
		//		have the enemy ignore player damage
		//		teleport on top of player
		//		then slash downwards.
		Color originalColor = renderer.material.color;
		renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
		transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 7);
		Debug.Log (player.transform.position.x);
		Debug.Log(player.transform.position.y);
		renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, originalColor.a);
	}

}
