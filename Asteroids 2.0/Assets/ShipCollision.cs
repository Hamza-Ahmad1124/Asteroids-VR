using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour 
{
	public GameObject collisionExplosion;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Target")
		{
			GameObject player = GameObject.Find("Player");
			player.GetComponent<Player> ().hit();

			ContactPoint contact = collision.contacts[0];
			GameObject collisionExplode = Instantiate (collisionExplosion, contact.point, Quaternion.identity, transform) as GameObject;
			Destroy (collisionExplode, 6f);
		}
	}
}