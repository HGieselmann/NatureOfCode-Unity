using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleOneOne : MonoBehaviour
{

	public float x = 16;
	public float y = 9;
	public float xspeed = 15f;
	public float yspeed = 7.5f;

	public Transform Ball;

	// Use this for initialization
	void Start ()
	{
		Ball = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update ()
	{
		Ball.position += new Vector3(xspeed, yspeed,0) * Time.deltaTime;

		if (Ball.position.x > x || Ball.position.x < 0)
		{
			xspeed *= -1f;
		}
		if (Ball.position.y> y || Ball.position.y < 0)
		{
			yspeed *= -1f;
		}
		
		Debug.Log("Hi. This Code ran.");
		
		
	}
}
