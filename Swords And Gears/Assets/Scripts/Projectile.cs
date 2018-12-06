using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public GameObject particle;
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        particle = Instantiate(particle, transform.position, transform.rotation);
        Destroy(particle, 2f);
        Destroy(gameObject);
        /*if (collision.collider.tag == "Enemy")
        {
            
        }*/
    }
}
