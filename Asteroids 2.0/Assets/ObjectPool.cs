using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour 
{
	public static ObjectPool objectPool;
	public GameObject objectPrefab;
	public List<GameObject> objectList;
	public int amountOfPooledObjects = 20;

	void Awake()
	{
		objectPool = this;
	}

	void Start () 
	{
		objectList = new List<GameObject> ();

		for (int i = 0; i < amountOfPooledObjects; i++)
		{
			GameObject obj = (GameObject) Instantiate(objectPrefab);
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
}
