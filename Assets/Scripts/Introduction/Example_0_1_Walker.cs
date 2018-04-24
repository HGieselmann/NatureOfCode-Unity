using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Example_0_1_Walker : MonoBehaviour
{
	public float x, y, size;
	public Vector3 position;

	public GameObject sphere; 

	
	//Constructor
	public Example_0_1_Walker(float _x, float _y, float _size)
	{
		
		x = _x;
		y = _y;
		size = _size;
		Debug.Log(x + " " + y + " " + size +"Constructor run");
		position = new Vector3(x, y, 0f);
		sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		//Debug.Log(sphere + "Constructor");
		sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
	}
	
	public void RandomMove()
	{
		Debug.Log(sphere);
		Debug.Log("CodeRun");
		int choice = UnityEngine.Random.Range(1, 5); // 5 because Range is not inclusive
		if (choice == 1)
		{
			position += Vector3.up;
		} else if (choice == 2)
		{
			position+= Vector3.right;
		} else if (choice == 3)
		{
			position += Vector3.down;
		} else if (choice == 4)
		{
			position += Vector3.left;
		}
	}

	public void Display()
	{
		sphere.transform.position = position/10;
		
	}
}
