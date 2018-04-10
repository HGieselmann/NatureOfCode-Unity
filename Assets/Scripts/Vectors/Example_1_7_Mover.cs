using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Example_1_7_Mover : MonoBehaviour {
	
	public static int CSizeX = 16;
	public static int CSizeY = 9;
	

	public Vector3 location;
	private Vector3 velocity;

	// Call me Captn Constructor
	public Example_1_7_Mover()
	{
		location = new Vector3(UnityEngine.Random.Range(0,CSizeX), UnityEngine.Random.Range(0, CSizeY), 0f);
		velocity = new Vector3(UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(-2,2), 0f);
			
	}

	public void UpdatePosition()
	{
		location += velocity * Time.deltaTime;
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
