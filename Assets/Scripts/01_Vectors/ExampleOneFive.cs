using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ExampleOneFive: MonoBehaviour
{
	// ----------------------------------------------------------------------------//	
	// THIS EXAMPLE USES THE RIGIDBODY SYSTEM OF THE QUAD TO CALCULATE A POINT ----//
	// ----------------------------------------------------------------------------//
	// ----------------------------------------------------------------------------//
	
	// Setting the Size for our 'fake' Canvas
	public int CSizeX = 16;
	public int CSizeY = 9;
	
	// Creating variables for components, set them up in the editor!
	public LineRenderer line_direction;
	public LineRenderer line_magnitude;
	public Camera Cam;
	private Ray mousepos;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

		Vector3 center = new Vector3(CSizeX/2, CSizeY/2, 0f);
		//Shoot a Ray (raymouse) at the through the MousePosition, create Raycast hit variable, get position of hit
		Ray rayMouse = Cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit pos;
		Physics.Raycast(rayMouse, out pos);
		Debug.Log(pos.point);

		pos.point -= center; // we can just do this in Unity. No function needed
		float magnitude = pos.point.magnitude;
		//pos.point *= 0.5f;	 // And YES, we can do THIS too in Unity.  ¯\_(ツ)_/¯


		// Define the Start and Endpoint for the LineRenderer (direction)
		line_direction.SetPosition(0, center);
		line_direction.SetPosition(1, pos.point + center);
		
		line_magnitude.SetPosition(0, new Vector3(0,0,0));
		line_magnitude.SetPosition(1,new Vector3(magnitude, 0, 0));

	}


}
