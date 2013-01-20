using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 8; // Base movement speed of the player's ship
	
	private Vector3 vertical = new Vector3(0,1,0); // Unit y vector for creating ship velocity 
	private Vector3 horizontal = new Vector3(1,0,0); // Unit x vector for creating ship velocity
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Make ship velocity based on input
		// TODO: use sin/cos to make max velocity alway equal speed variable
		rigidbody.velocity = vertical * speed * Input.GetAxis("Vertical")
			+ horizontal * speed * Input.GetAxis("Horizontal");
	}
	
	void OnTriggerEnter(Collider collider) {
		// Stub for collision detection
		// TODO: create switch for different collision types
		Debug.Log(this.name + " collided with: " + collider.transform.name);
	}
	
	/*public void Hit() {
		Debug.Log ("Enemy Contact");
	}*/
}
