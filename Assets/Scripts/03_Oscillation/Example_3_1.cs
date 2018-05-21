using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_3_1 : MonoBehaviour
{


	[SerializeField] float sphereScale = 1f;
	[SerializeField] float sphereDistance = 1f;
	[SerializeField] float angularAcc = 0.001f;

	private Vector3 angularVel;
	private Vector3 angle;
	
	private GameObject nullObject;
	private GameObject sphere1;
	private GameObject sphere2;
	private GameObject line;

	// Use this for initialization
	void Start ()
	{

		// Initialize null
		nullObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
		// initialize spheres and Line
		sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere1.transform.localScale = new Vector3(sphereScale, sphereScale, sphereScale);
		sphere2.transform.localScale = new Vector3(sphereScale, sphereScale, sphereScale);
		sphere1.transform.position = new Vector3(sphereDistance, 0f, 0f);
		sphere2.transform.position = new Vector3(-sphereDistance, 0f, 0f);
		//Set parents
		sphere1.transform.parent = nullObject.transform;
		sphere2.transform.parent = nullObject.transform;
		


	}
	
	// Update is called once per frame
	void Update()
	{


		angularVel += new Vector3(0, 0, angularAcc);
		angle += angularVel;
		Debug.Log(angularVel);
		nullObject.transform.localRotation = Quaternion.Euler(angle);


}
}
