using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, 0, 0.2f));
		if(Input.GetKey(KeyCode.D))
			transform.Translate (new Vector3 (0.1f, 0, 0));
		if(Input.GetKey(KeyCode.A))
			transform.Translate (new Vector3 (-0.1f, 0, 0));
		if(Input.GetKey(KeyCode.W))
			transform.Translate (new Vector3 (0, 0, 0.1f));
		if(Input.GetKey(KeyCode.S))
			transform.Translate (new Vector3 (0, 0, -0.1f));
		if (Input.GetKey (KeyCode.J))
			transform.Rotate (new Vector3 (0,-1,0));
		if (Input.GetKey (KeyCode.L))
			transform.Rotate (new Vector3 (0,1,0));
		if (Input.GetKey (KeyCode.I))
			transform.Rotate (new Vector3 (1,0,0));
		if (Input.GetKey (KeyCode.K))
			transform.Rotate (new Vector3 (-1,0,0));
	}
	void OnCollisionEnter(Collision col)
	{
		
	}
}
