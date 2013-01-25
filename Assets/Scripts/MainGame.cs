using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {
	
	public GameObject playerShip; // Player's Ship Prefab
	public GameObject enemy; // Enemy Prefab
	public GameObject powerUp; // Power Up Prefab
	
	public float gameSpeed = 8; // Speed value that controls all movement in the game
	private int numPowerUpsCollected = 0; // Number of power ups collected, controls how many enemies spawn
	
	// Power up spawning variables
	public float triangleRadius = 10; // this is for a future fractal function, maybe 
	public Vector3 nextPowerUpPosition;
	public float nextPowerUpSpawnTime;
	public float timeBetweenPowerUps = 2;
	private int numPowerUpsToSpawn = 1;
	
	// Enemy spawning variables
	public float enemyPositionRadius = 15;
	public Vector3 nextEnemyPosition;
	public float radBetweenSpawn = Mathf.PI / 8; // enemies spawn in a circular pattern for now
	private float enemySpawnTime = 3; // number of seconds before an enemy shows up
	private float timeBetweenEnemies = 0.75f;
	private float nextEnemySpawnTime;
	private float radForNextSpawn = 0;
	private int enemiesToSpawn = 0;

	public GameObject player; // Gameplay reference for player ship

	// Use this for initialization
	void Start () {
		CollidingObject.mainGame = this;
		
		nextEnemyPosition = new Vector3(enemyPositionRadius,0,0);
		nextPowerUpPosition = Vector3.zero;
		
		player = (GameObject) Instantiate (playerShip,Vector3.zero,Quaternion.identity);
		
		nextPowerUpSpawnTime = Time.timeSinceLevelLoad + timeBetweenPowerUps;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Spawn enemies if there are any left to spawn if it is passed spawn time
		if(enemiesToSpawn != 0 && Time.timeSinceLevelLoad > nextEnemySpawnTime) {
			generateEnemy(nextEnemyPosition);
			--enemiesToSpawn;
			nextEnemyPosition = getNextEnemyPosition();
			nextEnemySpawnTime = Time.timeSinceLevelLoad + timeBetweenEnemies;
		}
		
		// Spawn PowerUps same as enemies
		if(numPowerUpsToSpawn != 0 && Time.timeSinceLevelLoad > nextPowerUpSpawnTime) {
			generatePowerUp(nextPowerUpPosition);
			--numPowerUpsToSpawn;
			nextPowerUpPosition = getNextPowerUpPosition();
			nextPowerUpSpawnTime = Time.timeSinceLevelLoad + timeBetweenPowerUps;
		}
	}
	
	/// <summary>
	/// Increase the number of Power Ups and Enemies to spawn.
	/// </summary>
	public void powerUpCollected() {
		++numPowerUpsToSpawn;
		++numPowerUpsCollected;
		enemiesToSpawn += numPowerUpsCollected;
		nextPowerUpSpawnTime = Time.timeSinceLevelLoad + timeBetweenPowerUps;
		nextEnemySpawnTime = Time.timeSinceLevelLoad + timeBetweenEnemies;
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
	/// Gets the next enemy position.
	/// </summary>
	/// <returns>
	/// The next enemy position.
	/// </returns>/
	Vector3 getNextEnemyPosition() {
		radForNextSpawn += radBetweenSpawn;
		return new Vector3(Mathf.Cos(radForNextSpawn) * enemyPositionRadius,
					Mathf.Sin (radForNextSpawn) * enemyPositionRadius,0);
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
	
	/// <summary>
	/// Gets the next power up position.
	/// </summary>
	/// <returns>
	/// The next power up position.
	/// </returns>
	Vector3 getNextPowerUpPosition() {
		return Vector3.zero;
	}
}