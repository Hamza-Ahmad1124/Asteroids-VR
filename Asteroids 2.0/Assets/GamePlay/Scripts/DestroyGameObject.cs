using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour {

	private float lifeTime = 3f;

	void Start () 
	{
		Destroy (this.gameObject, lifeTime);
	}	
}
