using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_3_11 : MonoBehaviour
{
	private float CSizeX = 16;
	private float CSizeY = 9;

	private LineRenderer line;
	private Spring spring;
	public Bob bob;

	private GameObject sphere;
	// Use this for initialization
	void Start ()
	{
		line = gameObject.AddComponent<LineRenderer>();
		line.widthMultiplier = 0.2f;
		sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		bob = new Bob(8, 2f);
		spring = new Spring(8,9,5);
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 gravity = new Vector3(0, 2, 0);
		bob.applyForce(gravity);
		spring.connect(bob);
		bob.update();
		sphere.transform.position = bob.position;
		
		line.SetPosition(0,spring.origin);
		line.SetPosition(1, bob.position);
		
		

	}
}