using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {
	
	public GameObject playerShip; // Player's Ship Prefab
	public GameObject enemy; // Enemy Prefab
	public GameObject powerUp; // Power Up Prefab
	
	public float gameSpeed = 8; // Speed value that controls all movement in the game
	
	// these 3 variables are for the possible fractal position for power ups
	public float triangleRadius = 10;
	public Vector3 nextEnemyPosition;
	public Vector3 nextPowerUpPosition;
	
	private float spawnTime = 3; // number of seconds before an enemy shows up
	private bool spawned = false; // spawning variable for when  not continually spawning the enemies
	private GameObject player; // Gameplay reference for player ship

	// Use this for initialization
	void Start () {
		nextEnemyPosition = new Vector3(10,0,0);
		nextPowerUpPosition = Vector3.zero;
		
		player = (GameObject) Instantiate (playerShip,Vector3.zero,Quaternion.identity);
		// Set player speed to gameSpeed
		Player playerCtl = player.GetComponent<Player>();
		playerCtl.speed = gameSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(!spawned && Time.time > spawnTime) {
			generateEnemy(new Vector3(10,10,0));
			spawned = true;
		}
	}
	
	/// <summary>
	/// Generates the enemy.
	/// </summary>
	/// <param name='pos'>
	/// Enemy's initial position.
	/// </param>
	void generateEnemy(Vector3 pos){
		GameObject enemyShip = (GameObject) Instantiate(enemy,pos,Quaternion.identity);
		
		// Get vector towards player
		Vector3 enemyVelocity = player.transform.position - enemyShip.transform.position;
		// Set enemy velocity at 75% of gamespeed
		enemyShip.rigidbody.velocity = enemyVelocity.normalized * gameSpeed * 0.75f; 
	}
	
	/// <summary>
	/// Generates the power up.
	/// </summary>
	/// <param name='pos'>
	/// Power up's initial position.
	/// </param>
	void generatePowerUp(Vector3 pos){
		Instantiate(powerUp,pos,Quaternion.identity);
	}
	
	Vector3 getNextEnemyPosition() {
		return Vector3.zero;
	}
}