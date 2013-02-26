using UnityEngine;
using System.Collections;

public class Enemy : CollidingObject {
	
	private Vector3 startPosition;
	
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
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
	
	public override void boundaryExit () {
		transform.position = startPosition;
	}
}
