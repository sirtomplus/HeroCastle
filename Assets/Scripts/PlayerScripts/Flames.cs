using UnityEngine;
using System.Collections;

public class Flames : MonoBehaviour {
	ArrayList enemies;
	public int damage;
	public float timeToLive;
	private float killTime;
	public float timeBetweenTicks;
	private float nextTick;
	// Use this for initialization
	void Start () {
		enemies = new ArrayList();
		killTime = Time.time + timeToLive;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		//Do this because OnTriggerStay2D will only damage 1 enemy at a time
		//but we want to do damage to all enemies inside the hitbox
		if(Time.time > nextTick){
			foreach(Collider2D enemy in enemies){
				try{
					enemy.gameObject.GetComponent<Enemy>().Hurt(damage);
				}
				catch(MissingReferenceException){
					enemies.Clear();
				}
				if(enemy.gameObject.GetComponent<Enemy>().HP <= damage){
					enemies.Remove(enemy);
				}

//				enemy.gameObject.GetComponent<Enemy>().Hurt(damage);
			}
			nextTick = Time.time + timeBetweenTicks;
		}
		if(Time.time > killTime)
			Destroy(gameObject);

	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Enemy" || col.tag == "Boss"){
			enemies.Add(col);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Enemy" || col.tag == "Boss"){
			enemies.Remove(col);
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.tag == "Enemy" || col.tag == "Boss"){
			if(!enemies.Contains(col)){
				enemies.Add(col);
			}
		}
	}

}
