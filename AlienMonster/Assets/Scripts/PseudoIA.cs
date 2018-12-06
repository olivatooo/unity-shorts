using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoIA : MonoBehaviour {
	private Rigidbody rb;
	private int distance = 50;
	private GameObject target;
	public int maxHeight = 5;
	private bool jump = false;
	private bool flee = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		target = GameObject.FindGameObjectWithTag ("Target");
	}
	
	// Update is called once per frame
	void Update () {
		checkWalls ();
		//Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		//Debug.DrawRay(transform.position, forward, Color.green);
		followObject(target,true);
	}
	void checkWalls()
	{
		//Debug.DrawRay (transform.position*10,Vector3.right*10, Color.blue);
		/*if (Physics.Raycast (transform.position,Vector3.right, 10) || Physics.Raycast (transform.position,Vector3.left, 10) ) {
			rb.AddForce (10, 10, 10);
		}*/
	}
	void followObject(GameObject obj,bool follow)
	{
		if (Physics.Raycast (transform.position,Vector3.down, 10))
			{
		if(follow)
			rb.AddForce (-(transform.position - obj.transform.position).normalized * distance + obj.transform.position);
		else
			rb.AddForce ((transform.position - obj.transform.position).normalized * distance + obj.transform.position);
			}
	}
}
