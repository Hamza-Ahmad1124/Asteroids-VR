using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidController : MonoBehaviour
{
	public int numberOfAsteroids = 10;

	private ObjectPool asteroidPool;

	private bool asteroidsAlive = true;

	void Start ()
	{
		asteroidPool = this.GetComponent<ObjectPool>();

		for (int i = 0; i < numberOfAsteroids; i++)
		{
			GameObject asteroidObject = asteroidPool.getPooledObject();
			asteroidObject.transform.SetParent (this.transform);
			asteroidObject.SetActive (true);
		}
	}
	
	void LateUpdate () 
	{
		if (asteroidsAlive)
		{
			CheckIfAllAsteroidsDestroyed ();
		}
	}

	private void CheckIfAllAsteroidsDestroyed()
	{
		if (asteroidPool.AreAllObjectsInActive())
		{
			asteroidsAlive = false;
			Invoke ("LoadNextScene", 15f);
		}
	}

	public void LoadNextScene()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex - 1);
	}
}