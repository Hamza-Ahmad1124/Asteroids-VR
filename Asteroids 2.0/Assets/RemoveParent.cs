using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveParent : MonoBehaviour {

	private Vector3 parentPosition;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (this.gameObject.transform.parent != null)
		{
			parentPosition = this.gameObject.transform.parent.position;

			if (  (parentPosition.x >= 90)
				||(parentPosition.x <= -90)
				||(parentPosition.y >= 90)
				||(parentPosition.y <= -90)
				||(parentPosition.z >= 90)
				||(parentPosition.z <= -90))
			{
				this.gameObject.transform.parent = null;
			}
		}
	}
}
