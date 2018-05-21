using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_3_6 : MonoBehaviour
{

	private float CSizeX = 16;
	private float CSizeY = 9;
	
	private GameObject sphere;
	public float angularVel = 5f; // Bigger Value because we use Time.deltaTime;
	public float amplitude = 8;
	private float angle;
	
	// Use this for initialization
	void Start ()
	{
		sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		

	}
	
	// Update is called once per frame
	void Update ()
	{

		angle += angularVel * Time.deltaTime;
		float x = amplitude * Mathf.Cos(angle+Time.time/2);
		float y = (amplitude/2) * Mathf.Cos(angle+45+Time.time);
		
		sphere.transform.position = new Vector3(x + CSizeX/2, y+CSizeY/2, 0f );
		
	}
}
