using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
	public int numberOfAsteroids = 10;

	void Start ()
	{
		ObjectPool asteroidPool = this.GetComponent<ObjectPool>();

		for (int i = 0; i < numberOfAsteroids; i++)
		{
			GameObject asteroidObject = asteroidPool.getPooledObject();
			asteroidObject.transform.SetParent (this.transform);
			asteroidObject.SetActive (true);
		}
	}
	
	void Update () 
	{}
}