﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Ship : MonoBehaviour 
{
	public float movementSpeed = 250f;
	public float turnSpeed = 50f;
	public float health = 5f;
	private float startHealth;
	public GameObject collisionExplosion;

	public GameObject shipExplosion;

	private GameObject booster;

	private static bool isHit = false;   // To Stop continuous hit

	public Image healthBar;

	void Start()
	{
		booster = GameObject.Find ("Engine Fire");

		startHealth = health;
	}

	void Update () 
	{
		if ((Input.GetAxis ("Vertical") != 0))
		{
			Thrust ();	
		} 

		else
		{
			booster.SetActive (false);
		}

		if((Input.GetAxis ("Pitch") != 0) || (Input.GetAxis ("Yaw") != 0) || (Input.GetAxis ("Roll") != 0))
		{
			Turn ();
		}

		if (isHit)
		{
			Invoke ("ResetIsHit", 1f);
		}
	}

	void Thrust()
	{
		booster.SetActive (true);

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
			GameObject finalExplosion = (GameObject)Instantiate (shipExplosion);
			finalExplosion.transform.position = this.transform.position;

			Destroy (finalExplosion, 5f);
			Invoke ("LoadCurrentScene", 6f);

			this.gameObject.SetActive (false);
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
			if (isHit)
			{
				return;
			} 

			else
			{
				isHit = true;

				Hit ();
			}

			ContactPoint contact = collision.contacts[0];

			GameObject collisionExplode = (GameObject)Instantiate (collisionExplosion);
			collisionExplode.transform.position = contact.point;
			collisionExplode.transform.SetParent (this.transform);

			Destroy (collisionExplode, 6f);
		}
	}

	void ResetIsHit()
	{
		isHit = false;
	}
}