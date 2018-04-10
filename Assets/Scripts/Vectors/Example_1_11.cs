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



public class Example_1_11 : MonoBehaviour
{

	[SerializeField] static int NoOfSpheres = 20;
	private Example_1_11_Mover[] mover = new Example_1_11_Mover[NoOfSpheres];
	GameObject[] spheres = new GameObject[NoOfSpheres];
//	GameObject.CreatePrimitive(PrimitiveType.Sphere);
//	sphere.transform.position = new Vector3(0, 1.5F, 0);
	
	Ray mousePosRay = new Ray();
	public Camera myCam;
	public RaycastHit pos;
	

	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < mover.Length; i++)
		{
			mover[i] = new Example_1_11_Mover();
			spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			spheres[i].transform.position = new Vector3(UnityEngine.Random.value,UnityEngine.Random.value, UnityEngine.Random.value);
			
		}
		

	}
	
	// Update is called once per frame
	void Update ()
	{

		mousePosRay = myCam.ScreenPointToRay(Input.mousePosition);
		
		Physics.Raycast(mousePosRay, out pos);

		for (int i = 0; i < mover.Length; i++)
		{
			mover[i].UpdatePosition(pos.point);
			mover[i].CheckEdges();
			spheres[i].transform.position = new Vector3(mover[i].location.x, mover[i].location.y, 0f);
		}
		


	}
	


}
