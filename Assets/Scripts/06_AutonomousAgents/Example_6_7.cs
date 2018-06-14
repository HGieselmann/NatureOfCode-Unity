using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_6_7 : MonoBehaviour
{
	public Example_6_7_Flock flock;

	// Use this for initialization
	void Start () {
		flock = new Example_6_7_Flock();
		for (int i = 0; i < 200; i++)
		{
			Example_6_7_Boid b = new Example_6_7_Boid( Random.RandomRange(0,16), Random.RandomRange(0,9), Random.RandomRange(-1,1));
			flock.addBoid(b);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		flock.run();
		
	}
}
