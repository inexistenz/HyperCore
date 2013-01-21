using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {
	
	public GameObject playerShip; // Player's Ship Prefab
	public GameObject enemy; // Enemy Prefab
	public GameObject powerUp; // Power Up Prefab
	
	public float gameSpeed = 8; // Speed value that controls all movement in the game
	
	
	private float spawnTime = 3; 
	private bool spawned = false;
	private GameObject player; // Gameplay reference for player ship
	// Use this for initialization
	void Start () {
		player = (GameObject) Instantiate (playerShip,Vector3.zero,Quaternion.identity);
		// Set player speed to gameSpeed
		PlayerControl playerCtl = player.GetComponent<PlayerControl>();
		playerCtl.speed = gameSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(!spawned && Time.time > spawnTime) {
			generateEnemy(new Vector3(10,10,0));
			spawned = true;
		}
	}
	
	// Enemy generation function
	void generateEnemy(Vector3 pos){
		GameObject enemyShip = (GameObject) Instantiate(enemy,pos,Quaternion.identity);
		
		// Get vector towards player
		Vector3 enemyVelocity = player.transform.position - enemyShip.transform.position;
		// Set enemy velocity at 75% of gamespeed
		enemyShip.rigidbody.velocity = enemyVelocity.normalized * gameSpeed * 0.75f; 
	}
	
	// Power up generation function
	void generatePowerUp(Vector3 pos){
		Instantiate(powerUp,pos,Quaternion.identity);
	}
}