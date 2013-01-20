using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {
	
	public GameObject player;
	public GameObject enemy;
	public GameObject powerUp;
	
	private float spawnTime = 3;
	private bool spawned = false;
	private GameObject ship;
	// Use this for initialization
	void Start () {
		ship = (GameObject) Instantiate (player,Vector3.zero,Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		//spawned = true;
		if(!spawned && Time.time > spawnTime) {
			GameObject enemyShip = (GameObject) Instantiate(enemy, new Vector3(10,10,0),Quaternion.identity);
			Vector3 enemyVelocity = ship.transform.position - enemyShip.transform.position;
			enemyShip.rigidbody.velocity = enemyVelocity.normalized * 8;
			spawned = true;
		}
	}
}