using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceWrap : MonoBehaviour 
{
	void OnTriggerExit(Collider collider)
	{
		if (collider.transform.tag == "Target")
		{
			collider.transform.position *= -1 ;

			int randomValue = Random.Range (0 , 3);

			if (randomValue == 0)
			{
			//	collider.transform.position = new Vector3 ((collider.transform.position.x * -1), (collider.transform.position.y * -1) , collider.transform.position.z);
			}

			else if (randomValue == 1)
			{
			//	collider.transform.position = new Vector3 (collider.transform.position.x , (collider.transform.position.y * -1), (collider.transform.position.z * -1));
			}

			else if (randomValue == 2)  
			{
			//	collider.transform.position = new Vector3 ((collider.transform.position.x * -1) , collider.transform.position.y , (collider.transform.position.z * -1));
			}
		}
	}
}
