using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float xMargin = 1f;
	public float yMargin = 1f;
	public float xSmooth = 8f;
	public float ySmooth = 8f;
	public Vector2 maxXandY;
	public Vector2 minXandY;
	private Vector2 _velocity;
	private BarPosition _barPos;
	public float xOffset = 2f;

	private Transform player;

	void Awake () {
		player = GameObject.FindGameObjectWithTag( "Player" ).transform;
		_barPos = GameObject.FindGameObjectWithTag("BarsAnchor").GetComponent<BarPosition>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	void FixedUpdate() {

	}

	void LateUpdate(){
		//Tracking the player in LateUpdate() follows smoother
		if(player != null){
			TrackPlayer();
			_barPos.moveBars();
		}
	}

	bool CheckXMargin(){
		return Mathf.Abs( transform.position.x - player.position.x ) > xMargin;
	}

	bool CheckYMargin(){
		return Mathf.Abs( transform.position.y - player.position.y ) > yMargin;
	}

	void TrackPlayer(){
		float targetX = transform.position.x;
		float targetY = transform.position.y;


		if( CheckXMargin () ){
			targetX = Mathf.Lerp ( transform.position.x, player.position.x, xSmooth * Time.deltaTime );
		}

		if( CheckYMargin () ){
			targetY = Mathf.Lerp ( transform.position.y, player.position.y, ySmooth * Time.deltaTime );
		}
		targetX = Mathf.Clamp( targetX, minXandY.x, maxXandY.x );
		targetY = Mathf.Clamp( targetY, minXandY.y, maxXandY.y );

		transform.position = new Vector3( targetX, targetY, transform.position.z );
	}

	public void stopTracking(){
		player = null;
	}

	public void setPosition(Vector3 position){
		transform.position = new Vector3(position.x, position.y, -10);
	}

	public void setMax(Vector2 max){
		maxXandY = max;
	}

	public void setMin(Vector2 min){
		minXandY = min;
	}
}
