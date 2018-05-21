using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_0_5 : MonoBehaviour
{

	private GameObject sphere;
	[SerializeField] private float xScale;
	[SerializeField] private float yScale;
	
	// Use this for initialization
	void Start ()
	{
		sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		

	}
	
	// Update is called once per frame
	void Update ()
	{
		float xPos = (Mathf.PerlinNoise(Time.time, 0.0f) * xScale) -xScale/2;
		float yPos = (Mathf.PerlinNoise(Time.time + 100f, 0.0f) * yScale) -yScale/2;

		sphere.transform.position = new Vector3(xPos, yPos, 0f);



	}
}
