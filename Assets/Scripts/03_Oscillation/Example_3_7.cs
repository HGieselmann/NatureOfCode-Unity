using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Example_3_7 : MonoBehaviour
{

	[SerializeField] static int NoOfSpheres = 20;
	private Oscillator[] oscillators = new Oscillator[NoOfSpheres];
	GameObject[] spheres = new GameObject[NoOfSpheres];

	
	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < oscillators.Length; i++)
		{
			oscillators[i] = new Oscillator();
			spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			spheres[i].transform.position = new Vector3(UnityEngine.Random.value,UnityEngine.Random.value, UnityEngine.Random.value);
		}

		

	}
	
	// Update is called once per frame
	void Update ()
	{

		
		for (int i = 0; i < oscillators.Length; i++)
		{
			oscillators[i].Oscillate();
			spheres[i].transform.position = new Vector3(oscillators[i].x, oscillators[i].y, 0);
		}
		
	}
}



public class Oscillator : MonoBehaviour
{
	private float CSizeX = 16;
	private float CSizeY = 9;


	public Vector3 angularVel;// Bigger Value because we use Time.deltaTime;
	public Vector3 amplitude;
	private Vector3 angle;

	public float x, y;

	public Oscillator()
	{
		angle = new Vector3(0,0,0);
		amplitude = new Vector3(UnityEngine.Random.Range(-CSizeX/2, CSizeX/2), UnityEngine.Random.Range(-CSizeY/2, CSizeY/2), 0);
		angularVel= new Vector3(UnityEngine.Random.Range(-5, 5), UnityEngine.Random.Range(-5, 5), 0);
	}
	
	// Update is called once per frame
	public void Oscillate ()
	{

		angle += angularVel * Time.deltaTime;
		
		
		x = (amplitude.x * Mathf.Cos(angle.x)) + CSizeX/2;
		y = (amplitude.y * Mathf.Cos(angle.y)) + CSizeY/2;
		
	}
	
	
	
	
}