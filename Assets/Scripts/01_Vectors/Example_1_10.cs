using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Example_1_10 : MonoBehaviour {
	
	public Example_1_10_Mover MyMover;
	public GameObject mySphere;
	
	Ray mousePosRay = new Ray();
	public Camera myCam;
	public RaycastHit pos;
	

	// Use this for initialization
	void Start ()
	{
		
		MyMover = new Example_1_10_Mover();
		mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		//mySphere = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update ()
	{

		mousePosRay = myCam.ScreenPointToRay(Input.mousePosition);
		
		Physics.Raycast(mousePosRay, out pos);
		
		MyMover.UpdatePosition(pos.point);
		MyMover.CheckEdges();
		mySphere.transform.position = new Vector3(MyMover.location.x, MyMover.location.y, 0f);


	}
	


}
