﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObject : MonoBehaviour {

	public float lifeTime = 4f;

	void Start () 
	{
		InvokeRepeating ("Disable", lifeTime, lifeTime);	
	}
	
	void Disable()
	{
		this.gameObject.SetActive (false);
	}
}
