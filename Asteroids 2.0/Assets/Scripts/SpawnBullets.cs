using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour {

	public float shootingCooldown = 0.5f;
	private float shootingTimer;
	private ObjectPool bulletPool;

	// Use this for initialization
	void Start () 
	{
		bulletPool = this.gameObject.GetComponentInParent<ObjectPool> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		shootingTimer -= Time.deltaTime;

		//if (Input.GetKeyDown(KeyCode.Space) && shootingTimer <= 0f)
		if (shootingTimer <= 0f)
		{
			GameObject bulletObject = bulletPool.getPooledObject ();

			if (bulletObject == null)
			{
				return;
			}

			bulletObject.transform.parent = null;

			//bulletObject.transform.SetParent (GameObject.Find("GvrEditorEmulator").transform);

			//bulletObject.transform.LookAt (this.transform.forward);

			bulletObject.transform.rotation = this.transform.rotation;

			bulletObject.transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z);

			Bullet bullet = bulletObject.GetComponent<Bullet> ();

			bullet.direction = this.transform.forward;	

			bulletObject.SetActive (true);

			shootingTimer = shootingCooldown;
		}
	}
}
