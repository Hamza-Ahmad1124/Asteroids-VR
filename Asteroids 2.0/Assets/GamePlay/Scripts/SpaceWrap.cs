using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceWrap : MonoBehaviour 
{
	void OnTriggerExit(Collider collider)
	{
		if (collider.transform.name == "GvrEditorEmulator")
		{
			collider.transform.position *= -1;

			GameObject ship = GameObject.Find ("Ship");

			ship.transform.position *= -1;
		}

		if (collider.transform.tag == "Bullets")
		{
			Bullet bullet = collider.GetComponent<Bullet>();
			bullet.Disable ();
		}

		if (collider.transform.tag == "Target")
		{
			collider.transform.position *= -1 ;
		}
	}
}