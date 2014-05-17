using UnityEngine;
using System.Collections;

public class AutoFade : MonoBehaviour {
	Color color = Color.black;
	// Use this for initialization
	void Start () {
//		DontDestroyOnLoad(this);
		StartCoroutine("FadeIn");
	}
	
	// Update is called once per frame
	void Update () {
//		if( color.a > 0 ){
//			color.a += -0.02f;
//			renderer.material.color = color;
//		}
//		StartCoroutine("FadeIn");
	}

	IEnumerator FadeIn(){
		yield return new WaitForSeconds(0.5f);
		for(float f = 1f; f >= 0; f -= 0.1f){
//			Color c = renderer.material.color;
			color.a = f;
			renderer.material.color = color;
			yield return new WaitForSeconds(0.1f);
		}
		Destroy(gameObject);
	}

	public void Fade(){
		StartCoroutine("FadeIn");
	}
//	public void FadeIn(){
//		if( color.a > 0 ){
//			color.a += -0.02f;
//			renderer.material.color = color;
//		}
//	}
//
//	public void FadeOut(){
//		if( color.a < 1 ){
//			color.a += 0.02f;
//			renderer.material.color = color;
//		}
//	}
}
