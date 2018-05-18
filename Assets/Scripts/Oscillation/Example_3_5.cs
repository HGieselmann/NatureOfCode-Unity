using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_3_5 : MonoBehaviour
{

	private float CSizeX = 16;
	private float CSizeY = 9;
	private GameObject sphere;
	private float x;

	public float period = 120f;
	public float amplitude = 1000f;
	
	
	// Use this for initialization
	void Start () {
		sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		
	}
	
	// Update is called once per frame
	void Update () {
		 x = amplitude * Mathf.Cos(Mathf.PI*2 * Time.frameCount / period); // This is bad implementation based on frameCount
		 //x = amplitude * Mathf.Cos(Time.time); // Simpler based on time, smooth motion because it is not framerate dependent
		sphere.transform.position = new Vector3(x + CSizeX/2, CSizeY/2, 0);
		
		
		
	}
}
