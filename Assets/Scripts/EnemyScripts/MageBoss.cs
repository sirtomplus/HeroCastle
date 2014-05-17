using UnityEngine;
using System.Collections;

/*	Commands
 *	1	Fly
 *	2	Dive
 *	3	Rain
 *	4	Shoot
 *	5	Land
 */

public class MageBoss : Enemy {
	private Transform _player;
	private Transform groundCheck;
	private bool grounded;

	private bool waiting = false;

	private float BezierTime = 0f;
	private Vector2 _startPoint;
	private Vector2 _controlPoint;
	private Vector2 _endPoint;
	private Vector2 _curve;
	public float timeToEnd;
	private Transform _controlPointTransform;
	private Transform _endPointTransform;

	private int _command;

	private bool onRight = true;
	public float flightHeight = 7.4f;
	private float targetY;

	private int frameCount = 0;
	public int diveWait;
	public int shootWait;
	public int landWait;
	public int airShootWait;
	public int rainWait;

	private bool stunned = false;
	public int stunWait;

	public int teleportWait;
	private float rightPos = 13.1f;
	private float leftPos = -3.1f;

	private MageGun _mageGun;
	private MageAirGun _mageAirGun;

	private MageRainSpawnerParent _mageRainSpawner;

	public GameObject _teleporter;

	private DropItems _dropItems;

	void Awake(){
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		groundCheck = transform.FindChild("groundCheck");
		_controlPointTransform = transform.FindChild("ControlPoint");
		_endPointTransform = transform.FindChild("EndPoint");
		_mageGun = transform.FindChild("MageGun").GetComponent<MageGun>();
		_mageAirGun = transform.FindChild("MageAirGun").GetComponent<MageAirGun>();
		_mageRainSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<MageRainSpawnerParent>();
		_dropItems = transform.root.GetComponent<DropItems>();
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
	}

	// Use this for initialization
	void Start () {
		_startPoint = transform.position;
		_controlPoint = _controlPointTransform.position;
		_endPoint = _endPointTransform.position;
		_command = -1;
		act =  false;
		StartCoroutine(WaitForAnimations());
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("UnpassableGround"));
	}

	void FixedUpdate(){
		if(HP <= 0){
			GameObject.Find("Door").GetComponent<Door>().collider2D.enabled = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().killBoss(1);
			GameObject.FindGameObjectWithTag("BossManager").GetComponent<BossSceneManager>().ChangeBGM();
			_teleporter.SetActive(true);
			_dropItems.dropItem();
			Destroy(gameObject);
		}
		if(act && !stunned){
			_command = Random.Range(0, 5);
			if(_command == 0 && !grounded){
				//If Fly is chosen when already in the air, Dive, Rain, or Shoot instead
				_command += Random.Range (1, 4);
			}
			else if(_command == 1 && grounded){
				//If Dive is chosen when on the ground, Rain instead
				_command += Random.Range (1, 3);
			}
			else if(_command == 4 && grounded){
				//If Land is chosen when on the ground, Shoot instead
				_command--;
			}

			if(_command == 0){
				rigidbody2D.gravityScale = 0;
			}
			else if(_command == 1){
				_startPoint = transform.position;
				_controlPoint = _controlPointTransform.position;
				_endPoint = _endPointTransform.position;
			}
			else if(_command == 4){
				rigidbody2D.gravityScale = 1;
			}
			act = false;
		}

		if(!stunned){
			if(_command == 0){
				//Fly
				targetY = Mathf.Lerp (transform.position.y, flightHeight, Time.deltaTime);
					transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
				if(transform.position.y >= flightHeight - .1){
					act = true;
				}
			}
			else if(_command == 1){
				//Dive
				if(!waiting){
					_curve.x = (((1-BezierTime) * (1-BezierTime)) * _startPoint.x) + (2 * BezierTime * (1 - BezierTime) * _controlPoint.x) + ((BezierTime * BezierTime) * _endPoint.x);
					_curve.y = (((1-BezierTime) * (1-BezierTime)) * _startPoint.y) + (2 * BezierTime * (1 - BezierTime) * _controlPoint.y) + ((BezierTime * BezierTime) * _endPoint.y);
					transform.position = new Vector2(_curve.x, _curve.y);
					BezierTime += Time.deltaTime/timeToEnd;
					if(BezierTime >= 1){
						Flip ();
						onRight = !onRight;
						waiting = true;
						BezierTime = 0;
					}
				}
				if(waiting){
					frameCount++;
					if(frameCount >= diveWait){
						act = true;
						waiting = false;
						frameCount = 0;
					}
				}

			}
			else if(_command == 2){
				//Drop objects onto the player
				if(!waiting){
					_mageRainSpawner.Rain();
					waiting = true;
				}
				else{
					frameCount++;
					if(frameCount > rainWait){
						act = true;
						waiting = false;
						frameCount = 0;
					}
				}
			}
			else if(_command == 3 && grounded){
				//Shoot at projectiles at the player
				if(!waiting){
					_mageGun.Shoot();
					waiting = true;
				}
				else{
					frameCount++;
					if(frameCount > shootWait){
						act = true;
						waiting = false;
						frameCount = 0;
					}
				}
			}
			else if(_command == 3){
				if(!waiting){
					_mageAirGun.Shoot();
					waiting = true;
				}
				else{
					frameCount++;
					if(frameCount > airShootWait){
						act = true;
						waiting = false;
						frameCount = 0;
					}
				}
			}
			else if(_command == 4){
				//Land
				if(!waiting){
					rigidbody2D.gravityScale = 1;
					waiting = true;
				}
				else{
					if(grounded){
						frameCount++;
						if(frameCount > landWait){
							act = true;
							waiting = false;
							frameCount = 0;
						}
					}
				}
			}
		}
		else{
			frameCount++;
			if(frameCount > stunWait && !waiting){
				waiting = true;
				frameCount = 0;
				gameObject.layer = 0;
			}
			else if(frameCount > teleportWait && waiting){
				waiting = false;
				frameCount = 0;
				_command = 0;
				stunned = false;
				if(onRight){
					transform.position = new Vector3(rightPos, transform.position.y, transform.position.z);
				}
				else{
					transform.position = new Vector3(leftPos, transform.position.y, transform.position.z);
				}
				gameObject.layer = 10;
				rigidbody2D.gravityScale = 0;
			}
		}

	}

	void OnDestroy(){
		Destroy(GameObject.FindGameObjectWithTag("Spawner"));
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "EnemyBullet"){
			if(!stunned){
				stunned = true;
				waiting = false;
				KnockDown();
				frameCount = 0;
			}
		}
	}

	public bool getOnRight(){
		return onRight;
	}

	public void KnockDown(){
		rigidbody2D.gravityScale = 1;
		Vector3 hurtVector = transform.position - _player.position + Vector3.up * 2.5f;
		if(hurtVector.x < 0){
			hurtVector += Vector3.left*5f;
		}
		else{
			hurtVector += Vector3.right*5f;
		}
		rigidbody2D.velocity = new Vector2(0f, 0f);
		rigidbody2D.AddForce(new Vector2(hurtVector.x * 50f, hurtVector.y*50f/2));
	}

	IEnumerator WaitForAnimations(){
		yield return new WaitForSeconds(5.0f);
		act = true;
	}
}
