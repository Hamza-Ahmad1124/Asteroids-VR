using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour 
{
	private ObjectPool bulletPool;

	void Start () 
	{
		bulletPool = this.gameObject.GetComponentInParent<ObjectPool> ();
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bulletObject = bulletPool.getPooledObject ();

			if (bulletObject == null)
			{
				return;
			}

			bulletObject.transform.parent = null;

			bulletObject.transform.rotation = this.transform.rotation;

			bulletObject.transform.position = this.transform.position;

			Bullet bullet = bulletObject.GetComponent<Bullet> ();

			bullet.direction = this.transform.forward;	

			bulletObject.SetActive (true);
		}
	}
}