using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour {
	Vector2 position;
	// Use this for initialization
	void Awake()
	{
		GetComponent<Camera> ().orthographicSize = Screen.height / 2;
		position = transform.position;
		transform.position = new Vector3 (position.x - 0.1f, position.y -0.1f,-10);
	}
	void LateUpdate()
	{
		transform.position = new Vector3(position.x - 0.1f,  position.y -0.1f,-10);	
	}
}
