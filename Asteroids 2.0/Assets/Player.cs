using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
	public int pushForce = 100 ;
	public int health = 5;

	void Start ()
	{}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			Transform parentObject = this.transform.parent;
			parentObject.GetComponent<Rigidbody> ().isKinematic = false;
			parentObject.GetComponent<Rigidbody>().AddForce(transform.forward * pushForce);
		}

		checkIfOutOfBounds ();
	}

	public void hit()
	{
		health--;

		if (health == 0)
		{
			loadScene();
		}
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

	public void loadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}