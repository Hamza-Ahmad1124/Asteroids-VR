using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour 
{
	public float movementSpeed = 100f;
	public float turnSpeed = 50f;
	public int health = 5;
	public GameObject collisionExplosion;
	
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

		if (health <= 0)
		{
			LoadCurrentScene ();
		}
	}

	private void LoadCurrentScene()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
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