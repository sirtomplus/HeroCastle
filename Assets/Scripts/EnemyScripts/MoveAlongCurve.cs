using UnityEngine;
using System.Collections;

public class MoveAlongCurve : Enemy {
	private Vector2 StartPoint;
	public Vector2 ControlPoint;
	public Vector2 EndPoint;
	private Vector2 Curve;
	private float BezierTime = 0;
	public float TimeToEnd;
	public bool wait = false;
	public float distanceToAct;

	private Transform _controlPoint;
	private Transform _endPoint;

	private Animator _anim;

	void Awake(){
		_controlPoint = transform.FindChild("ControlPoint");
		_endPoint = transform.FindChild("EndPoint");
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
		_anim = GetComponentInChildren<Animator>();
		initItems();
	}


	// Use this for initialization
	void Start () {
//		FacePlayer();
		StartCoroutine(WaitToFacePlayer());
		act = false;
		StartPoint = transform.position;
		ControlPoint = _controlPoint.position;
		EndPoint = _endPoint.position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(HP <= 0){
			dropItems();
			Destroy(gameObject);
		}
		if(distance() < distanceToAct && !wait){
			StartCoroutine(WaitForDive());
		}
		if(act){
			Curve.x = (((1-BezierTime) * (1-BezierTime)) * StartPoint.x) + (2 * BezierTime * (1 - BezierTime) * ControlPoint.x) + ((BezierTime * BezierTime) * EndPoint.x);
			Curve.y = (((1-BezierTime) * (1-BezierTime)) * StartPoint.y) + (2 * BezierTime * (1 - BezierTime) * ControlPoint.y) + ((BezierTime * BezierTime) * EndPoint.y);
			transform.position = new Vector2(Curve.x, Curve.y);
			BezierTime += Time.deltaTime/TimeToEnd;
		}
		if(BezierTime >= 2){
			Destroy(this.gameObject);
		}
	}

	public float distance(){
		if(GameObject.FindWithTag("Player").transform != null){
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			return Mathf.Sqrt((player.position.x - transform.position.x)*(player.position.x - transform.position.x) - (player.position.y - transform.position.y)*(player.position.y - transform.position.y));
		}
		return 100f;
	}

	IEnumerator WaitForDive(){
		wait = true;
		_anim.SetBool("Fly", wait);
		yield return new WaitForSeconds(.7f);
		act = true;
	}

	IEnumerator WaitToFacePlayer(){
		yield return new WaitForSeconds(1.0f);
		FacePlayer();
		ControlPoint = _controlPoint.position;
		EndPoint = _endPoint.position;
	}
}
