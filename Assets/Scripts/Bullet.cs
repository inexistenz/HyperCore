using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider) {
		// Stub for collision detection
		// TODO: create switch for different collision types
		Debug.Log (this.name + " collided with: " + collider.transform.name);
	}
}
