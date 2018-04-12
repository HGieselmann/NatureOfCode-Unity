// THIS IS A PORT OF THE EXAMPLES FROM DANIEL SHIFFMANS BOOK "THE NATURE OF CODE" //
// The Original is found here: http://natureofcode.com/ and Licensed under : -----//
// Creative Commons Attribution-NonCommercial 3.0 Unported License. --------------//
// The Code Examples are licensend under:  GNU Lesser General Public License. ----//
// And so this Code is also licensed under:  GNU Lesser General Public License ---//
// I merely try to convert the Examples for Unity for personal use. If this helps //
// anyone else, I'm glad you found this Repo. Enjoy! -----------------------------//

// Special Thanks to "Rem", "Dora The Explorer" and "The Sith" @ N3K -------------//


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Example_2_8 : MonoBehaviour
{

	public float CSizeX = 16;
	public float CSizeY = 9;

	public Material refMaterial;
	

	// This is setup with Arrays on puropse, to be able to play with it faster
	public Example_2_8_Attractor Attractor;
	
	[SerializeField] static int NoOfSpheres = 20;
	private Example_2_8_Mover[] movers = new Example_2_8_Mover[NoOfSpheres];
	private GameObject[] spheres = new GameObject[NoOfSpheres];
	
	[SerializeField] Vector3 wind = new Vector3(0f, 0f, 0f);
	[SerializeField] Vector3 gravity = new Vector3(0f, -0f, 0f);
	// Use this for initialization
	void Start ()
	{
		Attractor = new Example_2_8_Attractor(CSizeX/2, CSizeY/2, 3, 0.2f);
		
		for (int i = 0; i < movers.Length; i++)
		{
			
			// TODO Fix NEW Warning when instatiating, make mono happy.
			movers[i] = new Example_2_8_Mover(UnityEngine.Random.value*4, (UnityEngine.Random.value -0.5f)* 20);
			spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			spheres[i].transform.position =
				new Vector3(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
			spheres[i].transform.localScale=
				new Vector3(0.02f, 0.02f, 0.02f);
			spheres[i].GetComponent<Renderer>().material = refMaterial;

		}




	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < movers.Length; i++)
		{
			Vector3 force = Attractor.attract(movers[i]);
			movers[i].applyForce(force);
			//movers[i].applyForce(wind);
			//movers[i].applyForce(gravity);
			movers[i].UpdatePosition();
			//movers[i].CheckEdges();
			spheres[i].transform.position = new Vector3(movers[i].location.x, movers[i].location.y, 0f);
		}




	}
	


}
