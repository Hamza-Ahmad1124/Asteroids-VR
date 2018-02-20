using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	public Vector3 direction;
	public float speed = 100f;
	public float lifeTime = 10f;

	void Update () 
	{
		transform.position += direction * speed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag == "Target")
		{
			Disable();
			Asteroid asteroid = collider.GetComponent<Asteroid> ();
			asteroid.Hit ();
		}
	}

	public void Disable()
	{
		this.gameObject.SetActive (false);
	}
}