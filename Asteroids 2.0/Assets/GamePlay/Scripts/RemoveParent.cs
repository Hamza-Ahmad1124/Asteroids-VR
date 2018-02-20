using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveParent : MonoBehaviour {

	private Vector3 parentPosition;

	void Start () 
	{}
	
	void Update () 
	{
		if (this.gameObject.transform.parent != null)
		{
			parentPosition = this.gameObject.transform.parent.position;

			if (  (parentPosition.x >= 95)
				||(parentPosition.x <= -95)
				||(parentPosition.y >= 95)
				||(parentPosition.y <= -95)
				||(parentPosition.z >= 95)
				||(parentPosition.z <= -95))
			{
				this.gameObject.transform.parent = null;
			}
		}
	}
}