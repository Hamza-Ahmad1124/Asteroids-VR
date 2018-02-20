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
	public GameObject asteroidPrefab;
	private bool isChild;

	void Start () 
	{
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

		//transform.rotation = Random.rotation;

		setDirections ();
	}

	// Update is called once per frame
	void Update () 
	{
		CheckHealth();
		rotation();
		//startMoving();
		checkIfOutOfBound ();
	}

	public void CheckHealth()
	{
		if (health <= 0)
		{
			if (gameObject.transform.localScale.x >= 4f)
			{
				CreateChildAsteroids (gameObject.transform.position, gameObject.transform.localScale);
			}

			Debug.Log (gameObject.transform.localScale.x.ToString());

			Destroy (gameObject);
		}
	}

	void CreateChildAsteroids(Vector3 position , Vector3 scale)
	{
		int NumberOfChildren = Random.Range (2, 5);

		for(int i = 0 ; i < NumberOfChildren ; i++)
		{
			GameObject asteroidObject = Instantiate (asteroidPrefab);
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

	void startMoving()
	{
		//GetComponent<Rigidbody>().AddForce(directions,);
		transform.position += directions;
	}

	void checkIfOutOfBound()
	{
		float Xposition = transform.position.x;
		float Yposition = transform.position.y;
		float Zposition = transform.position.z;

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

		transform.position = vectorPosition;
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