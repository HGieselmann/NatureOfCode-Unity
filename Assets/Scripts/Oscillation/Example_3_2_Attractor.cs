using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



public class Example_3_2_Attractor : MonoBehaviour
{


	public float mass;
	public Vector3 location;
	public float G; // our Gravitational Constant
	public GameObject AttractorSphere;
	
	// <<<--->>> Constructor <<<--->>>
	public Example_3_2_Attractor(float _x, float _y, float _m, float _G)
	{
		location = new Vector3(_x, _y, 0f);
		mass = _m;
		G = _G;
		AttractorSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		AttractorSphere.transform.position = location;
		AttractorSphere.transform.localScale = new Vector3(mass / 10, mass/10, mass/10);
	}

	public Vector3 attract(Example_2_7_Mover m)
	{
		Vector3 force = location - m.location;
		float distance = force.magnitude;
		// TODO Constrain to some sueful Values; Look up how to
		//distance.constrain;
		distance = Mathf.Clamp(distance, 0.1f, 6f);

		force = force.normalized;
		float Strength = (G * mass * m.mass) / (distance * distance);
		force *= Strength;
		return force;
	}




}
