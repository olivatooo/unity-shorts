using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int life = 100;
	public GameObject particle;
	public AudioClip myclip;
	public bool isTurret;
	private Vector2 myPos;
	public float speed;
	public GameObject bullet;
	public GameObject target;
	private Vector3 dir;

	void Start () {
		this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource>().clip = myclip;
		InvokeRepeating("Velocity",1,0.5f); 
	}
	void Velocity() {

		target = GameObject.FindGameObjectWithTag ("Player");
		myPos = new Vector2 (transform.position.x, transform.position.y+1);
		Vector3 sp = Camera.main.WorldToScreenPoint(target.transform.position);
		dir = (target.transform.position*Random.Range (0.1f, 10.0f) - sp).normalized;
		GameObject projectile = (GameObject)Instantiate(bullet, myPos, transform.rotation);
		projectile.GetComponent<Rigidbody2D>().velocity = dir * speed;
	

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
		this.GetComponent<AudioSource>().Play();
        if (collision.collider.tag == "Bullet")
        {
            Hit(10);
        }
    }
}
