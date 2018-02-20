using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour 
{
	public float movementSpeed = 1f;
	public float minimumDistance = 800f;
	public float minimumHeight = 800f;
	public float rotatingSpeed = 15f;
	public int health = 2;

	private int rotationSelection;
	private Vector3 directions;
	private bool isChild;
	private ObjectPool asteroidPool;
	private ObjectPool explosionPool;

	private Text scoreText;

	private static int score;

	void Start () 
	{
		scoreText = GameObject.Find ("Score").GetComponent<Text>();

		asteroidPool = this.gameObject.GetComponentInParent<ObjectPool>();

		GameObject ExplosionPoolObject = GameObject.Find("Explosion Pool");

		explosionPool = ExplosionPoolObject.GetComponent<ObjectPool> ();

		rotationSelection = Random.Range (1, 4);

		if (isChild == false)
		{
			//while (transform.position.x < 100 && transform.position.x > -100)
			{
				transform.position = new Vector3 
				(
					Random.Range(-minimumDistance, minimumDistance),
					Random.Range(-minimumHeight, minimumHeight),
					Random.Range(-minimumDistance, minimumDistance)
				);
			}
		}

		transform.rotation = Random.rotation;

		setDirections ();
	}

	void Update () 
	{
		rotation();
		startMoving();
	}

	public void CheckHealth()
	{
		if (health <= 0)
		{
			if (gameObject.transform.localScale.x >= 10f)
			{
				CreateChildAsteroids (gameObject.transform.position, gameObject.transform.localScale);
			}
				
			Explosion (gameObject.transform.position);

			Disable ();
		}
	}

	void Disable ()
	{
		SetAndDisplayScore ();

		this.gameObject.SetActive (false);
	}

	void CreateChildAsteroids(Vector3 position , Vector3 scale)
	{
		int NumberOfChildren = Random.Range (2, 6);

		for(int i = 0 ; i < NumberOfChildren ; i++)
		{
			GameObject asteroidObject = asteroidPool.getPooledObject();

			if (asteroidObject == null)
			{
				return;
			}

			asteroidObject.transform.SetParent (this.transform.parent);
			asteroidObject.transform.position = new Vector3((position.x + Random.Range(-2 , 3)), (position.y + Random.Range(-2 , 3)) , (position.z + Random.Range(-2 , 3)));

			float newScale = Random.Range(5f , ((scale.x / 1.5f) + 1));

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
			transform.RotateAround (this.transform.position, Vector3.right, rotatingSpeed * Time.deltaTime);

			//transform.rotation = Quaternion.Euler (rotatingSpeed, 0, 0) * transform.rotation;
			//transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + rotatingSpeed , 0 , 0);
		}

		else if (rotationSelection == 2)
		{
			transform.RotateAround (this.transform.position, Vector3.up, rotatingSpeed * Time.deltaTime);

			//transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + rotatingSpeed, 0);
		}

		else if (rotationSelection == 3)
		{
			transform.RotateAround (this.transform.position, Vector3.forward, rotatingSpeed * Time.deltaTime);

			//transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + rotatingSpeed);
		}
	}

	void Explosion(Vector3 startPosition)
	{
		GameObject explosion = explosionPool.getPooledObject();

		if (explosion == null)
		{
			return;
		}

		explosion.AddComponent<DisableGameObject>();
		explosion.transform.position = startPosition;
		explosion.SetActive (true);
	}

	void startMoving()
	{
		//GetComponent<Rigidbody>().AddForce(directions,);
		transform.position += directions * Time.deltaTime * 20;
	}

	public void Hit()
	{
		health--;

		CheckHealth();
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

	private void SetAndDisplayScore()
	{
		score = score + (int) this.transform.localScale.x;

		scoreText.text = "SCORE: " + score;
	}
}