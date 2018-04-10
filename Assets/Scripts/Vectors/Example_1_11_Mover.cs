using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Example_1_11_Mover : MonoBehaviour {
	
	public static int CSizeX = 16;
	public static int CSizeY = 9;
	
	public Vector3 location;
	private Vector3 velocity;
	private Vector3 acceleration;
	private Vector3 mousePos;
	private Vector3 dir;
	
	public float topspeed = 0.1f;
	
	
	// Call me Captn Constructor
	public Example_1_11_Mover()
	{
		;
		
		location = new Vector3(UnityEngine.Random.Range(0,CSizeX), UnityEngine.Random.Range(0, CSizeY), 0f);
		velocity = new Vector3(0f, 0f, 0f);
		acceleration = new Vector3( 0, 0, 0);
			
	}

	public void UpdatePosition(Vector3 _mousePos)
	{

		mousePos = _mousePos;
		dir = mousePos - location;
		dir = dir.normalized;
		dir *= 0.1f;
		acceleration = dir;
		
		
		//acceleration = ReturnRandomVector();
		velocity += acceleration * Time.deltaTime;
		velocity = Vector3.ClampMagnitude(velocity, topspeed); // Yes, PVector.limit is more beautiful...
		//Debug.Log(velocity);
		location += velocity ;
	}

	public static Vector3 ReturnRandomVector()
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
