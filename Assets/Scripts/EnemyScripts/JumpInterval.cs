using UnityEngine;
using System.Collections;

public class JumpInterval : MonoBehaviour {
//	public float jumpCD;
	private Enemy enemy;
	private Transform groundCheck;
	private bool grounded = false;

	void Awake(){
		groundCheck = transform.FindChild("groundCheck");
		enemy = transform.root.GetComponent<Enemy>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
			Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("UnpassableGround"));
	}

	void FixedUpdate(){
		if(enemy.act && grounded){
			rigidbody2D.velocity = new Vector2(0f, 0f);
			enemy.Jump ();
		}
	}
}
