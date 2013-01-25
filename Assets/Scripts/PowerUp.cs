using UnityEngine;
using System.Collections;

public class PowerUp : CollidingObject {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider) {
		CollidingObject co = collider.gameObject.GetComponent<CollidingObject>();
		co.powerUpCollision();
	}
	
	// Notifies the main game script that the power up was collected and destroys it
	public override void playerCollision() {
		mainGame.powerUpCollected();
		Destroy (gameObject);
	}
}