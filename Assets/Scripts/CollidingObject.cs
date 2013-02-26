using UnityEngine;
using System.Collections;


/// <summary>
/// Colliding object is the super class for all the objects
/// that can interact with each other in the game. This allows
/// calling of a generic function in all OnTriggerEnter calls
/// </summary>
public class CollidingObject : MonoBehaviour {
	
	public static MainGame mainGame;

	public virtual void playerCollision() { }
	
	public virtual void enemyCollision() { }
	
	public virtual void powerUpCollision() { }
	
	public virtual void bulletCollision() { }
	
	public virtual void boundaryExit() { }
}
