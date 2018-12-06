using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaGuy : MonoBehaviour {
	Rigidbody2D rb2d;
	float velocity = 20;
	float maxSpeed = 10;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(rb2d.velocity.magnitude > maxSpeed)
		{
			rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
		}
		if(Input.GetKey(KeyCode.D)){
			rb2d.AddForce (new Vector2 (velocity, 0));
			//rb2d.transform.Translate (new Vector2 (10, 0) * Time.deltaTime);
		}
		if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.A)) {
			rb2d.velocity = new Vector2 (0, 0);
		}
		if(Input.GetKey(KeyCode.A))
		{
			rb2d.AddForce (new Vector2 (-velocity, 0));
			//rb2d.transform.Translate (new Vector2 (-10, 0) * Time.deltaTime);
		}

	}
}
