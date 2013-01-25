using UnityEngine;
using System.Collections;

public class Enemy : CollidingObject {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider) {
		CollidingObject co = collider.gameObject.GetComponent<CollidingObject>();
		co.enemyCollision();
	}
	
	public override void bulletCollision () {
		Debug.Log ("Enemy shot!");
	}
}
