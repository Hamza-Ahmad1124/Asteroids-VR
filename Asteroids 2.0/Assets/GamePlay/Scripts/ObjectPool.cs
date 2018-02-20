using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour 
{
	public GameObject objectPrefab;
	public List<GameObject> objectList;
	public int amountOfPooledObjects;

	void Awake () 
	{
		objectList = new List<GameObject> ();

		for (int i = 0; i < amountOfPooledObjects; i++)
		{
			GameObject obj = (GameObject) Instantiate(objectPrefab);
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