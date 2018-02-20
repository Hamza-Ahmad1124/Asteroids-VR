using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
	public float shootingCooldown = 0.5f;
	private float shootingTimer;
	public int pushForce = 100 ;
	private ObjectPool bulletPool;

	void Start ()
	{
		bulletPool = this.gameObject.GetComponent<ObjectPool> ();
	}

	void Update ()
	{
		shootingTimer -= Time.deltaTime;

		//if (Input.GetKeyDown(KeyCode.Space) && shootingTimer <= 0f)
		if (shootingTimer <= 0f)
		{
			GameObject bulletObject = bulletPool.getPooledObject ();

			if (bulletObject == null)
			{
				return;
			}

			bulletObject.transform.SetParent (this.transform.parent);

			//bulletObject.transform.LookAt (this.transform.forward);

			bulletObject.transform.rotation = this.transform.rotation;

			bulletObject.transform.position = new Vector3(transform.position.x , transform.position.y - 1.5f, transform.position.z);

			Bullet bullet = bulletObject.GetComponent<Bullet> ();

			bullet.direction = this.transform.forward;	

			bulletObject.SetActive (true);
		
			shootingTimer = shootingCooldown;
		}


		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			Transform parentObject = this.transform.parent;

			parentObject.GetComponent<Rigidbody>().AddForce(transform.forward * pushForce);
		}

		checkIfOutOfBounds ();
	}

	void checkIfOutOfBounds()
	{
		Transform parentObject = this.transform.parent;

		float Xposition = parentObject.position.x;
		float Yposition = parentObject.position.y;
		float Zposition = parentObject.position.z;

		if (transform.position.x >= 100)
		{
			Xposition = -100;
		}

		else if (transform.position.x <= -100)
		{
			Xposition = 100;
		}

		if (transform.position.y >= 100)
		{
			Yposition = -100;
		}

		else if (transform.position.y <= -100)
		{
			Yposition = 100;
		}

		if (transform.position.z >= 100)
		{
			Zposition = -100;
		}

		else if (transform.position.z <= -100)
		{
			Zposition = 100;
		}

		Vector3 vectorPosition = new Vector3 (Xposition, Yposition, Zposition);

		parentObject.position = vectorPosition;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag == "Target")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}