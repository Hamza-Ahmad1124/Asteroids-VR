﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Ship : MonoBehaviour 
{
	public float movementSpeed = 100f;
	public float turnSpeed = 50f;
	public float health = 5f;
	private float startHealth;
	public GameObject collisionExplosion;

	public Image healthBar;

	void Start()
	{
		startHealth = health;
	}

	void Update () 
	{
		if ((Input.GetAxis ("Vertical") != 0) || (Input.GetAxis ("Pitch") != 0) || (Input.GetAxis ("Yaw") != 0) || (Input.GetAxis ("Roll") != 0))
		{
			Turn ();
			Thrust ();	
		}
	}

	void Thrust()
	{
		transform.position += transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis ("Vertical");
	}

	void Turn()
	{
		float pitch = turnSpeed * Time.deltaTime * Input.GetAxis ("Pitch"); // Rotation Around X axis
		float yaw = turnSpeed * Time.deltaTime * Input.GetAxis ("Yaw"); // Rotation Around Y axis
		float roll = turnSpeed * Time.deltaTime * Input.GetAxis ("Roll"); // Rotation Around Z axis

		transform.Rotate (-pitch , yaw , roll);
	}

	public void Hit()
	{
		health--;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0f)
		{
			LoadCurrentScene ();
		}
	}

	private void LoadCurrentScene()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex - 1);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Target")
		{
			Hit();

			ContactPoint contact = collision.contacts[0];

			GameObject collisionExplode = (GameObject)Instantiate (collisionExplosion);
			collisionExplode.transform.position = contact.point;
			collisionExplode.transform.SetParent (this.transform);

			Destroy (collisionExplode, 6f);
		}
	}
}