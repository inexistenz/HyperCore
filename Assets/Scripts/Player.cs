using UnityEngine;
using System.Collections;

public class Player : CollidingObject {
	
	public GameObject bullet; // Bullet prefab
	
	private Vector3 vertical = new Vector3(0,1,0); // Unit y vector for creating ship velocity 
	private Vector3 horizontal = new Vector3(1,0,0); // Unit x vector for creating ship velocity
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Make ship velocity based on input
		// TODO: use sin/cos to make max velocity always equal speed variable
		rigidbody.velocity = vertical * mainGame.gameSpeed * Input.GetAxis("Vertical")
			+ horizontal * mainGame.gameSpeed * Input.GetAxis("Horizontal");
		
		if(Input.GetButtonUp("Fire1")){
			fireBullet();
		}
	}
	
	void OnTriggerEnter(Collider collider) {
		CollidingObject co = collider.gameObject.GetComponent<CollidingObject>();
		co.playerCollision();
	}
	
	// Bullet generation function
	void fireBullet() {
		GameObject shot = (GameObject) Instantiate(bullet,transform.position,Quaternion.identity);
		float angle;
		Vector3 axis;
		transform.rotation.ToAngleAxis(out angle, out axis); // Get ship orientation
		shot.rigidbody.velocity = axis * mainGame.gameSpeed * 1.5f; // Fire bullet along that axis at 1.5x gamespeed
	}
	
	public override void powerUpCollision() {
		//Debug.Log ("Multiplier + Game Speed up!");
	}
	
	public override void enemyCollision() {
		Debug.Log ("Multiplier down");
	}
	/*public void Hit() {
		Debug.Log ("Enemy Contact");
	}*/
}
