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

public class Example_2_3 : MonoBehaviour
{

	// This is setup with Arrays on puropse, to be able to play with it faster
	[SerializeField] static int NoOfSpheres = 20;
	private Example_2_3_Mover[] movers = new Example_2_3_Mover[NoOfSpheres];
	private GameObject[] spheres = new GameObject[NoOfSpheres];
	private float[] RandMass = new float[NoOfSpheres];
	
	Ray mousePosRay = new Ray();
	public Camera myCam;
	public RaycastHit pos;
	
	[SerializeField] Vector3 wind = new Vector3(0.1f, 0f, 0f);
	[SerializeField] Vector3 gravity = new Vector3(0f, -0.1f, 0f);
	
	
	
	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < movers.Length; i++)
		{
			// TODO Fix NEW Warning when instatiating, make mono happy.
			RandMass[i] = UnityEngine.Random.value;
			movers[i] = new Example_2_3_Mover(RandMass[i], 0, 9f);
			spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			spheres[i].transform.position =
				new Vector3(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
			spheres[i].transform.localScale = new Vector3(RandMass[i],RandMass[i],RandMass[i]);
		}

	}
	
	// Update is called once per frame
	void Update ()
	{

		mousePosRay = myCam.ScreenPointToRay(Input.mousePosition);
		
		Physics.Raycast(mousePosRay, out pos);

		for (int i = 0; i < movers.Length; i++)
		{
			movers[i].applyForce(wind);
			movers[i].applyForce(gravity * RandMass[i]);
			movers[i].UpdatePosition();
			movers[i].CheckEdges();
			spheres[i].transform.position = new Vector3(movers[i].location.x, movers[i].location.y, 0f);
		}

	}

}
