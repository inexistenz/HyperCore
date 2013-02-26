using UnityEngine;
using System.Collections;

public class Boundary : CollidingObject {
	
	// Use this for initialization
	void Start () {
		// Create play area by assigning the size of the box collider
		Camera cam = mainGame.mainCamera.camera;
		BoxCollider c = collider as BoxCollider;
		
		// orthographicSize is used to determine the size of the play area
		float playHeight = cam.orthographicSize * 2;
		float playWidth = playHeight * cam.aspect;
		
		// camera distance from origin is used specify depth
		float playDepth = Mathf.Abs(cam.transform.position.z * 2);	

		c.size = new Vector3(playWidth,playHeight,playDepth);
	}
	
	// Update is called once per frame
	void Update () {
		// BoxCollider c = collider as BoxCollider;
		//	Debug.Log(c.size);
	}
	
	void OnTriggerExit(Collider collider) {
		CollidingObject co = collider.gameObject.GetComponent<CollidingObject>();
		co.boundaryExit();
	}
}
