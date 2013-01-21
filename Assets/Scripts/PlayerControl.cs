using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	public GameObject bullet; // Bullet prefab
	public float speed; // Base movement speed of the player's ship
	
	private Vector3 vertical = new Vector3(0,1,0); // Unit y vector for creating ship velocity 
	private Vector3 horizontal = new Vector3(1,0,0); // Unit x vector for creating ship velocity
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Make ship velocity based on input
		// TODO: use sin/cos to make max velocity always equal speed variable
		rigidbody.velocity = vertical * speed * Input.GetAxis("Vertical")
			+ horizontal * speed * Input.GetAxis("Horizontal");
		
		if(Input.GetButtonUp("Fire1")){
			fireBullet();
		}
	}
	
	void OnTriggerEnter(Collider collider) {
		// Stub for collision detection
		// TODO: create switch for different collision types
		Debug.Log(this.name + " collided with: " + collider.transform.name);
	}
	
	// Bullet generation function
	void fireBullet() {
		GameObject shot = (GameObject) Instantiate(bullet,transform.position,Quaternion.identity);
		float angle;
		Vector3 axis;
		transform.rotation.ToAngleAxis(out angle, out axis); // Get ship orientation
		shot.rigidbody.velocity = axis * speed * 1.5f; // Fire bullet along that axis at 1.5x gamespeed
	}

	/*public void Hit() {
		Debug.Log ("Enemy Contact");
	}*/
}
