using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public Vector3 velocity = new Vector3 (1, 1, 1);
	public Vector3 defaultDistance = new Vector3 (2.7f , 4f , -13f);
	public float smoothTime = 0.1f;

	void Update () 
	{
		SmoothFollow ();
	}

	void SmoothFollow()
	{
		Vector3 destinationPosition = target.position + (target.rotation * defaultDistance);
		Vector3 currentPosition = Vector3.SmoothDamp (this.transform.position, destinationPosition , ref velocity, smoothTime , 500f , Time.deltaTime);
		this.transform.position = currentPosition;

		//this.transform.LookAt (target , target.up);
		this.transform.rotation = target.rotation;
	}
}
