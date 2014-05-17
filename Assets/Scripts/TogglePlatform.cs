using UnityEngine;
using System.Collections;

public class TogglePlatform : MonoBehaviour {
	public float disableTime;
	public float activeTime;
	public AudioClip toggleSound;
	public bool startDisabled;
	public float initialDisableTime;
	private float nextDisableTime;
	private Transform _ChildPlatform;
	private bool toggling = false;
	private Volume _volume;

	void Awake(){
		_ChildPlatform = transform.FindChild("TogglePlatform");
		_volume = GameObject.Find ("Volume").GetComponent<Volume>();
	}

	// Use this for initialization
	void Start () {
		if(startDisabled){
			StartCoroutine(Toggle (initialDisableTime));
			toggling = true;
		}
		else{
			nextDisableTime = activeTime + Time.time;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if(Time.time > nextDisableTime && !toggling){
			toggling = true;
			StartCoroutine(Toggle(disableTime));
		}
	}

	IEnumerator Toggle(float disable){
		if(distance() < 8f){
			AudioSource.PlayClipAtPoint(toggleSound, transform.position, _volume.SFXVol);
		}
		_ChildPlatform.gameObject.SetActive(false);
		yield return new WaitForSeconds(disable);
		_ChildPlatform.gameObject.SetActive(true);
		if(distance() < 8f){
			AudioSource.PlayClipAtPoint(toggleSound, transform.position, _volume.SFXVol);
		}
		toggling = false;
		nextDisableTime = Time.time + activeTime;
	}

	float distance(){
		if(GameObject.FindWithTag("Player").transform != null){
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			return Mathf.Sqrt((player.position.x - transform.position.x)*(player.position.x - transform.position.x) - (player.position.y - transform.position.y)*(player.position.y - transform.position.y));
		}
		return 100f;
	}
}
