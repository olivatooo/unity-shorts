using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody rb;
	//private CharacterController cc;
	private Vector3 moveDirection = Vector3.zero;
	public float force = 0.1f;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();

	}

	// Update is called once per frame
	void Update () {
		
		rb.transform.LookAt(rb.transform.position);
		if (Input.GetKey (KeyCode.W)) {
			//UP
			moveDirection = Vector3.left;
			rb.transform.Translate (moveDirection*force);
		}
		if (Input.GetKey (KeyCode.S)) {
			//DOWN
			moveDirection = Vector3.right;
			rb.transform.Translate (moveDirection*force);
		}

	}
}
