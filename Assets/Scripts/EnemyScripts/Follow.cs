using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	private Enemy enemy;
	// Use this for initialization
	void Start () {
		enemy = transform.parent.GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = enemy.transform.position;
	}
}
