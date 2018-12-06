using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	public int life = 100;
	public GameObject particle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Hit(int damage)
	{
		life=life - damage;
		if(life<=0)
		{
			particle = Instantiate(particle, transform.position, transform.rotation);
			Destroy(particle, 1f);
			Destroy(gameObject);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		//this.GetComponent<AudioSource>().Play();
		if (collision.collider.tag == "Bullet")
		{
			Hit(10);
		}
	}
}
