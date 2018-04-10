using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleOneTwo_3D : MonoBehaviour
{

	public float CSizeX = 16;
	public float CSizeY = 9;
	public float CSizeZ = 16;
	private Vector3 velocity = new Vector3(15f, 7.5f, 25f);

	public Transform Ball;

	// Use this for initialization
	void Start ()
	{
		Ball = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update ()
	{
		Ball.position += velocity * Time.deltaTime;

		if (Ball.position.x > CSizeX || Ball.position.x < 0)
		{
			velocity.x *= -1f;
		}
		if (Ball.position.y> CSizeY || Ball.position.y < 0)
		{
			velocity.y *= -1f;
		}

		if (Ball.position.z > CSizeZ || Ball.position.z < 0)
		{
			velocity.z *= -1f;
		}


	}
}
