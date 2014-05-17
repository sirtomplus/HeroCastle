using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	Color color = Color.white;
	void Awake(){
	}

	// Use this for initialization
	void Start () {
		color.a = 0f;
		renderer.material.color = color;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Fade(){
		StartCoroutine(FadeIn());
	}

	public void enableGameOverText(){
		this.enabled = true;
	}

	IEnumerator FadeIn(){
		for(float f = 0f; f <= 1; f += 0.05f){
			color.a = f;
			renderer.material.color = color;
			yield return new WaitForSeconds(0.1f);
		}
	}
}
