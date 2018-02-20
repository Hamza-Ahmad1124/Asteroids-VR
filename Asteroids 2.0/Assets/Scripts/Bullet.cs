﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	public Vector3 direction;
	public float speed = 100f;
	public float lifeTime = 10f;

	void Update () 
	{
		transform.position += direction * speed * Time.deltaTime;

		//transform.LookAt (direction);
		//transform.GetComponent<Rigidbody> ().AddForce (direction * 100);
		//transform.Translate (direction * speed * Time.deltaTime, Space.Self);
	   	//transform.position = Vector3.MoveTowards(transform.position, direction * 300 , speed * Time.deltaTime);
		//transform.rotation = Quaternion.LookRotation (transform.forward);
		//transform.rotation = Quaternion.FromToRotation(transform.forward , direction);
		//transform.LookAt (direction);
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag == "Target")
		{
			Disable();
			Asteroid asteroid = collider.GetComponent<Asteroid> ();
			//asteroid.Hit ();	
		}
	}

	public void Disable()
	{
		this.gameObject.SetActive (false);
	}
}