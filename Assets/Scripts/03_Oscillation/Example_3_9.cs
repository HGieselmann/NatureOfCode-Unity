using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Example_3_9 : MonoBehaviour
{

	[SerializeField] static int NoOfSpheres = 16;
	private Oscillator_3_9[] oscillators = new Oscillator_3_9[NoOfSpheres];
	GameObject[] spheres = new GameObject[NoOfSpheres];

	public float angleMult = 0.25f;
	
	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < oscillators.Length; i++)
		{
			oscillators[i] = new Oscillator_3_9(i,angleMult);
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



public class Oscillator_3_9 : MonoBehaviour
{
	private float CSizeX = 16;
	private float CSizeY = 9;


	public Vector3 angularVel;// Bigger Value because we use Time.deltaTime;
	public Vector3 amplitude;
	private Vector3 angle;

	public float x, y;

	public Oscillator_3_9(int i, float angleMult)
	{
		
		
		angle = new Vector3(i,i*angleMult,0);
		amplitude = new Vector3(0, CSizeY/2, 0f);
		angularVel= new Vector3(0,5,0);
	}
	
	// Update is called once per frame
	public void Oscillate ()
	{

		angle += angularVel * Time.deltaTime;


		x = angle.x;
		y = (amplitude.y * Mathf.Cos(angle.y)) + CSizeY/2;
		
	}
	
	
	
	
}