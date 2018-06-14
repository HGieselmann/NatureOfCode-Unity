using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_6_8 : MonoBehaviour
{
	public Example_6_8_Flock flock;

	// Use this for initialization
	void Start () {
		flock = new Example_6_8_Flock();
		for (int i = 0; i < 100; i++)
		{
			Example_6_8_Boid b = new Example_6_8_Boid( Random.RandomRange(-1,1), Random.RandomRange(-1,1), Random.RandomRange(-1,1));
			flock.addBoid(b);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		flock.run();
		
	}
}
