using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
	public GameObject bulletPrefab;
	public float shootingCooldown = 0.5f;
	private float shootingTimer;
	public int pushForce = 100 ;
	public int NoOfPush = 0;

	// Use this for initialization
	void Start () 
	{}

	// Update is called once per frame
	void Update ()
	{
		shootingTimer -= Time.deltaTime;

		//if (Input.GetKeyDown(KeyCode.Space) && shootingTimer <= 0f)
		if (shootingTimer <= 0f)
		{
			GameObject bulletObject = Instantiate (bulletPrefab);

			bulletObject.transform.position = new Vector3(transform.position.x , transform.position.y - 1.1f, transform.position.z);

			//bulletObject.transform.SetParent (this.transform.parent);

			float bulletXRotation = bulletObject.transform.localEulerAngles.x;
			float bulletYRotation = bulletObject.transform.localEulerAngles.y;
			float bulletZRotation = bulletObject.transform.localEulerAngles.z;

			bulletXRotation += transform.localEulerAngles.x;
			bulletYRotation += transform.localEulerAngles.y;
			bulletZRotation += transform.localEulerAngles.z;

			bulletObject.transform.localEulerAngles = new Vector3(bulletXRotation , bulletYRotation , bulletZRotation);

			Bullet bullet = bulletObject.GetComponent<Bullet> ();

			bullet.direction = this.transform.forward;
		
			shootingTimer = shootingCooldown;
		}


		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			Transform parentObject = this.transform.parent;
			//parentObject.position += transform.forward;

			if (NoOfPush <= 3)
			{
				parentObject.GetComponent<Rigidbody>().AddForce(transform.forward * pushForce);
			}
		}

		checkIfOutOfBounds ();
	}

	void checkIfOutOfBounds()
	{
		Transform parentObject = this.transform.parent;

		float Xposition = parentObject.position.x;
		float Yposition = parentObject.position.y;
		float Zposition = parentObject.position.z;

		if (transform.position.x >= 100)
		{
			Xposition = -100;
		}

		else if (transform.position.x <= -100)
		{
			Xposition = 100;
		}

		if (transform.position.y >= 100)
		{
			Yposition = -100;
		}

		else if (transform.position.y <= -100)
		{
			Yposition = 100;
		}

		if (transform.position.z >= 100)
		{
			Zposition = -100;
		}

		else if (transform.position.z <= -100)
		{
			Zposition = 100;
		}

		Vector3 vectorPosition = new Vector3 (Xposition, Yposition, Zposition);

		parentObject.position = vectorPosition;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag == "Target")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}