using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairFollow : MonoBehaviour {

	public GameObject mainBody;

	// Use this for initialization
	void Start () 
	{
		//this.transform.position = mainBody.transform.position + new Vector3 (0.05f, 4f, -10.5f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = mainBody.transform.position + (mainBody.transform.rotation * new Vector3 (0.05f, 4f, -10.5f));
	}
}
