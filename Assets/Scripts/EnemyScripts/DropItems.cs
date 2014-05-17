using UnityEngine;
using System.Collections;

[System.Serializable]
public class itemData{
	public Rigidbody2D item;
	public float itemChance;
}

public class DropItems : MonoBehaviour {
	public itemData[] items;
//	public float dropChance;
//	Enemy enemy;

	void Awake(){

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void dropItem(){
		foreach(itemData i in items){
			if(Random.Range(0, 100) < i.itemChance){
				Instantiate(i.item, transform.position, Quaternion.Euler( new Vector3(0f, 0f, 0f)));
				break;
			}
		}
	}
}
