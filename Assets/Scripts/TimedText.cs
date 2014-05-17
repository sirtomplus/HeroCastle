using UnityEngine;
using System.Collections;

public class TimedText : MonoBehaviour {
	public float timeToLive;
	private bool isActive = false;
	private float killTime;
	private bool fadingOut = false;
	Color color;

	void Awake(){
		color = renderer.material.color;
	}

	// Use this for initialization
	void Start () {
		color.a = 0f;
		renderer.material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(isActive){
			if(Time.time > killTime && !fadingOut){
				StartCoroutine(FadeoutText());
			}
		}
	}

	public void Fadein(){
		if(!isActive){
			StartCoroutine(FadeinText());
		}
	}

	IEnumerator FadeinText(){
		isActive = true;
		fadingOut = false;
		killTime = Time.time + timeToLive;
		for(float f = 0f; f <= 1; f += 0.1f){
			color.a = f;
			renderer.material.color = color;
			yield return new WaitForSeconds(0.1f);
		}
	}

	IEnumerator FadeoutText(){
		fadingOut = true;
		for(float f = 1f; f >= 0; f -= 0.1f){
			color.a = f;
			renderer.material.color = color;
			yield return new WaitForSeconds(0.1f);
		}
		color.a = 0;
		renderer.material.color = color;
		isActive = false;
	}
}
