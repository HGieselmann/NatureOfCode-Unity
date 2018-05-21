using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class Example_0_3_Walker : MonoBehaviour
{
	public float x, y, size;
	public Vector3 position;

	public GameObject sphere; 

	//Constructor
	public Example_0_3_Walker(float _x, float _y, float _size)
	{
		
		x = _x;
		y = _y;
		size = _size;
		position = new Vector3(x, y, 0f);
		sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
	}
	
	public void RandomMove()
	{
		float choice = UnityEngine.Random.value; // 5 because Range is not inclusive
		if (choice < 0.2f)
		{
			position += Vector3.up;
		} else if (choice < 0.6f)
		{
			position+= Vector3.right;
		} else if (choice < 0.8f)
		{
			position += Vector3.down;
		} else
		{
			position += Vector3.left;
		}
	}

	public void checkEdges()
	{
		if (position.x > 80)
		{
			position.x = 80;
		}
	}

	public void Display()
	{
		sphere.transform.position = position/10;
		
	}
}
