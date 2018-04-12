// THIS IS A PORT OF THE EXAMPLES FROM DANIEL SHIFFMANS BOOK "THE NATURE OF CODE" //
// The Original is found here: http://natureofcode.com/ and Licensed under : -----//
// Creative Commons Attribution-NonCommercial 3.0 Unported License. --------------//
// The Code Examples are licensend under:  GNU Lesser General Public License. ----//
// And so this Code is also licensed under:  GNU Lesser General Public License ---//
// I merely try to convert the Examples for Unity for personal use. If this helps //
// anyone else, I'm glad you found this Repo. Enjoy! -----------------------------//


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_2_5 : MonoBehaviour
{

	// Set the CanvasSize
	public static int CSizeX = 16;
	public static int CSizeY = 9;
	
	//Create the Liquid
	private Example_2_5_Liquid Liquid;
	
	// This is setup with Arrays on puropse, to be able to play with it faster
	[SerializeField] static int NoOfSpheres = 20;
	private Example_2_5_Mover[] movers = new Example_2_5_Mover[NoOfSpheres];
	private GameObject[] spheres = new GameObject[NoOfSpheres];
	private float[] RandMass = new float[NoOfSpheres];
	
	public Camera myCam;
	
	// Create Forces;
	[SerializeField] Vector3 wind = new Vector3(0.1f, 0f, 0f);
	[SerializeField] Vector3 gravity = new Vector3(0f, -0.1f, 0f);
	[SerializeField] private float frictionCoef = 0.01f;
	private Vector3 friction;
	private Vector3 drag;
	
	
	
	
	// Use this for initialization
	void Start ()
	{
		Liquid = new Example_2_5_Liquid(CSizeX / 2, CSizeY / 2, CSizeX, CSizeY, 20);
		Liquid.displayLiquid();	
		
		
		for (int i = 0; i < movers.Length; i++)
		{
			// TODO Fix NEW Warning when instatiating, make mono happy.
			RandMass[i] = UnityEngine.Random.value;
			// TODO Fix positioning
			movers[i] = new Example_2_5_Mover(RandMass[i], i*CSizeX / movers.Length, 9f);
			spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			spheres[i].transform.position =
				new Vector3(UnityEngine.Random.value , UnityEngine.Random.value, UnityEngine.Random.value);
			spheres[i].transform.localScale = new Vector3(RandMass[i],RandMass[i],RandMass[i]);
			
		}

	}
	
	// Update is called once per frame
	void Update ()
	{

		//
		for (int i = 0; i < movers.Length; i++)
		{
			friction = movers[i].velocity;
			friction *= -1;
			friction = friction.normalized;
			friction *= frictionCoef;

			// This is all the Liquid Drag Calculations
			// probably belongs in a seperate function
			float speed = movers[i].velocity.magnitude;
			float dragMagnitude = Liquid.c * speed * speed;
			drag = movers[i].velocity * -1;
			drag = drag.normalized;
			drag *= dragMagnitude;
			Vector3 Ldrag = drag.normalized * dragMagnitude;
			
			

			if (movers[i].IsInsideLiquid(Liquid))
			{
				movers[i].applyForce(Ldrag);
			};
			movers[i].applyForce(friction);
			movers[i].applyForce(wind);
			movers[i].applyForce(gravity * RandMass[i]);
			movers[i].UpdatePosition();
			movers[i].CheckEdges();
			spheres[i].transform.position = new Vector3(movers[i].location.x, movers[i].location.y, 0f);
		}

	}

}
