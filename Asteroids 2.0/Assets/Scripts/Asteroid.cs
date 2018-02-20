using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour 
{
	public float movementSpeed = 0.3f;
	public float minimumDistance = 80f;
	public float minimumHeight = 80f;
	public float rotatingSpeed = 1f;
	public int rotationSelection;
	public Vector3 directions;
	public int health = 2;
	private bool isChild;
	private ObjectPool asteroidPool;
	private ObjectPool explosionPool;

	void Start () 
	{
		asteroidPool = this.gameObject.GetComponentInParent<ObjectPool>();

		GameObject ExplosionPoolObject = GameObject.Find("Explosion Pool");

		explosionPool = ExplosionPoolObject.GetComponent<ObjectPool> ();

		rotationSelection = Random.Range (1, 4);

		if (isChild == false)
		{
			transform.position = new Vector3 
			(
				Random.Range(-minimumDistance, minimumDistance),
				Random.Range(-minimumHeight, minimumHeight),
				Random.Range(-minimumDistance, minimumDistance)
			);
		}

		transform.rotation = Random.rotation;

		setDirections ();
	}

	void Update () 
	{
		CheckHealth();
		//rotation();
		//startMoving();
	}

	public void CheckHealth()
	{
		if (health <= 0)
		{
			if (gameObject.transform.localScale.x >= 4f)
			{
				CreateChildAsteroids (gameObject.transform.position, gameObject.transform.localScale);
			}
				
			Explosion (gameObject.transform.position);

			Disable ();
		}
	}

	void Disable ()
	{
		this.gameObject.SetActive (false);
	}

	void CreateChildAsteroids(Vector3 position , Vector3 scale)
	{
		int NumberOfChildren = Random.Range (2, 5);

		for(int i = 0 ; i < NumberOfChildren ; i++)
		{
			GameObject asteroidObject = asteroidPool.getPooledObject();

			if (asteroidObject == null)
			{
				return;
			}

			asteroidObject.transform.SetParent (this.transform.parent);
			asteroidObject.transform.position = new Vector3((position.x + Random.Range(-1 , 2)), (position.y + Random.Range(-1 , 2)) , (position.z + Random.Range(-1 , 2)));

			float newScale = 0f;

			while(newScale <= 2f)
			{
				newScale = Random.Range(1f , ((scale.x / 2f) + 1));
			}

			asteroidObject.transform.localScale = new Vector3 (newScale, newScale, newScale);

			Asteroid asteroid = asteroidObject.GetComponent<Asteroid> ();
			asteroid.health = 2;
			asteroid.isChild = true;

			asteroidObject.SetActive (true);
		}
	}

	void rotation()
	{
		if (rotationSelection == 1)
		{
			transform.rotation = Quaternion.Euler (rotatingSpeed, 0, 0) * transform.rotation;
	//		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + rotatingSpeed , 0 , 0);
		}

		else if (rotationSelection == 2)
		{
			transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + rotatingSpeed, 0);
		}

		else if (rotationSelection == 3)
		{
			transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + rotatingSpeed);
		}
	}

	void Explosion(Vector3 startPosition)
	{
		GameObject explosion = explosionPool.getPooledObject();
		explosion.transform.position = startPosition;
		explosion.SetActive (true);
	}

	void startMoving()
	{
		//GetComponent<Rigidbody>().AddForce(directions,);
		transform.position += directions;
	}

	public void Hit()
	{
		health--;
	}

	void setDirections()
	{
		directions = new Vector3 (Random.Range (-1f, 1.1f) * movementSpeed, Random.Range (-1f, 1.1f) * movementSpeed, Random.Range (-1f, 1.1f) * movementSpeed);

		while (directions.x == 0 && directions.y == 0 && directions.z == 0)
		{
			directions.x = Random.Range (-1f, 1.1f) * movementSpeed;
			directions.y = Random.Range (-1f, 1.1f) * movementSpeed;
			directions.z = Random.Range (-1f, 1.1f) * movementSpeed;
		}
	}
}