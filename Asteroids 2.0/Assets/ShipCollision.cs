using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipCollision : MonoBehaviour 
{
	public GameObject collisionExplosion;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag == "Target")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Target")
		{
			ContactPoint contact = collision.contacts[0];
			GameObject collisionExplode = Instantiate (collisionExplosion, contact.point, Quaternion.identity, transform) as GameObject;
			Destroy (collisionExplode, 6f);
		}
	}
}