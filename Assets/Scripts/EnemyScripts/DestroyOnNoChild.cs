using UnityEngine;
using System.Collections;

public class DestroyOnNoChild : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(transform.childCount == 0){
			Destroy(gameObject);
		}
	}
}
