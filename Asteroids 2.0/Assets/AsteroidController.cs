using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour 
{
	public GameObject asteroidPrefab;
	public int numberOfAsteroids = 15;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < numberOfAsteroids; i++)
		{
			GameObject asteroidObject = Instantiate (asteroidPrefab);
			asteroidObject.transform.SetParent (this.transform);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
