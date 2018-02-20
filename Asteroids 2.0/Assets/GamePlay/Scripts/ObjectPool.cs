using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour 
{
	public List<GameObject> objectPrefab;
	public List<GameObject> objectList;
	public int amountOfPooledObjects;

	public bool asteroids = false;

	void Awake () 
	{
		objectList = new List<GameObject> ();

		for (int i = 0; i < amountOfPooledObjects; i++)
		{
			GameObject obj ;

			if (asteroids)
			{
				obj = (GameObject)Instantiate (objectPrefab[Mathf.RoundToInt(Random.Range(0f , 2.5f))]);
			} 

			else
			{
				obj = (GameObject) Instantiate(objectPrefab[0]);	
			}

			obj.transform.SetParent (this.gameObject.transform);
			obj.SetActive (false);
			objectList.Add (obj);
		}	
	}
	
	public GameObject getPooledObject()
	{
		for (int i = 0; i < amountOfPooledObjects; i++)
		{
			if (!(objectList [i].activeInHierarchy))
			{
				return objectList [i];
			}
		}

		return null;
	}

	public bool AreAllObjectsInActive() // Are All Objects InActive ?
	{
		for (int i = 0; i < amountOfPooledObjects; i++)
		{
			if ((objectList [i].activeInHierarchy))
			{
				return false;
			}
		}

		return true;
	}
}