using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public Vector3 velocity = Vector3.zero;
	public Vector3 defaultDistance = new Vector3 (0.05f , 4f , -13f);
	public float smoothTime = 0.06f;

	void LateUpdate () 
	{
		SmoothFollowPosition ();
		SmoothFollowRotation ();	
	}

	void SmoothFollowPosition()
	{
		Vector3 destinationPosition = target.position + (target.rotation * defaultDistance);
		Vector3 currentPosition = Vector3.SmoothDamp (this.transform.position, destinationPosition , ref velocity, smoothTime , 500f , Time.deltaTime);
		this.transform.position = currentPosition;
	}

	void SmoothFollowRotation()
	{
		this.transform.rotation = target.rotation;

		//this.transform.LookAt (target , target.up);
		//this.transform.rotation = Quaternion.Slerp (this.transform.rotation , target.rotation , 0.5f);
	}
}
