using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Example_1_9_Mover : MonoBehaviour {
	
	public static int CSizeX = 16;
	public static int CSizeY = 9;
	

	public Vector3 location;
	private Vector3 velocity;
	private Vector3 acceleration;

	public float topspeed = 10;
	

	// Call me Captn Constructor
	public Example_1_9_Mover()
	{
		location = new Vector3(UnityEngine.Random.Range(0,CSizeX), UnityEngine.Random.Range(0, CSizeY), 0f);
		velocity = new Vector3(0f, 0f, 0f);
		acceleration = new Vector3( 0, 0, 0);
			
	}

	public void UpdatePosition()
	{
		acceleration = ReturnRandomVector();
		Debug.Log(acceleration);
		velocity += acceleration;
		velocity = Vector3.ClampMagnitude(velocity, topspeed); // Yes, PVector.limit is more beautiful...
		//Debug.Log(velocity);
		location += velocity * Time.deltaTime;
	}

	private Vector3 ReturnRandomVector()
	{
		//returns a normalized random Vector
		Vector3 randV =  new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f),UnityEngine.Random.Range(-1f, 1f));
		return randV.normalized;

	}

	public void CheckEdges()
	{
		if (location.x > CSizeX)
		{
			location.x = 0;
		} else if (location.x < 0)
		{
			location.x = CSizeX;
		}

		if (location.y > CSizeY)
		{
			location.y = 0;
		} else if (location.y < 0)
		{
			location.y = CSizeY;
		}
	}


}
