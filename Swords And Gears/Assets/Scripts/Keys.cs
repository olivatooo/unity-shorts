using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour {
	Animator anim;
    public int velocity = 2;
    public int jumpForce = 10;
	public GameObject particle;
	public int Health;
    public GameObject bullet;
	private Rigidbody2D rb;
    public float speed;
	public Text scoreText;
	private bool isGrounded;
	private bool onLadder;
	private static float GroundAngleTolerance = Mathf.Cos(20.0f * Mathf.Deg2Rad);
	private Vector2 myPos;
	private Vector2 mouse;
	public AudioClip myclip;
    void Start () {
		
		anim = GetComponent<Animator>();
		anim.Play ("Idle");
		this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource>().clip = myclip;
        rb = GetComponent<Rigidbody2D>();
		scoreText.text = "Health:" + Health;
    }
	void OnBecameInvisible()
	{
		Health = 0;
	}
	// Update is called once per frame
	void Update () {
		if (Health <= 0) {
			Application.LoadLevel (Application.loadedLevel);
		}
        if (Input.GetKey("d"))
        {
			
            transform.Translate(velocity*Vector3.right * Time.deltaTime, Camera.main.	transform);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(velocity * Vector3.left * Time.deltaTime, Camera.main.transform);
        }
		if (Input.GetKeyDown("space")&&isGrounded==true)
        {			
			isGrounded = false;
			rb.velocity = new Vector3(0, 18, 0); 
        }
        if(Input.GetMouseButtonDown(0))
        {
			//mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
		  	myPos = new Vector2 (transform.position.x, transform.position.y+1);
			this.GetComponent<AudioSource>().Play();

            Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = (Input.mousePosition - sp).normalized;
            GameObject projectile = (GameObject)Instantiate(bullet, myPos, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

    }
	void OnCollisionEnter2D(Collision2D coll) 
	{
		foreach(ContactPoint2D contact in coll.contacts)
		{
			if (Vector3.Dot (contact.normal, Vector3.up) > GroundAngleTolerance) {
				isGrounded = true;
			} 
		}

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		

	}



}
