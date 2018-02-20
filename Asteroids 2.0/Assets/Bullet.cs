using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	public Vector3 direction;
	public float speed = 30f;
	public float lifeTime = 10f;
	public int timer = 1;

	// Use this for initialization
	void Start ()
	{}

	// Update is called once per frame
	void Update () 
	{
		if (timer <= 0)
		{
			//this.transform.parent = null;	
		}

		transform.position += direction * speed * Time.deltaTime;

		//transform.GetComponent<Rigidbody> ().AddForce (direction * 100);
		//transform.Translate (direction * speed * Time.deltaTime, Space.Self);
	//	transform.position = Vector3.MoveTowards(transform.position, direction * 300 , speed * Time.deltaTime);
		//transform.rotation = Quaternion.LookRotation (transform.forward);
		//transform.rotation = Quaternion.FromToRotation(transform.forward , direction);
		//transform.LookAt (direction);

		lifeTime -= Time.deltaTime;

		if (lifeTime <= 0f)
		{
			Destroy (gameObject);
		}

		timer--;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag == "Target")
		{
			Destroy (gameObject);
			Asteroid asteroid = collider.GetComponent<Asteroid> ();
			//asteroid.Hit ();	
		}
	}
}
