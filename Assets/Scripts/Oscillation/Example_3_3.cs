using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Example_3_3 : MonoBehaviour {
	
	public Example_3_3_Mover MyMover;
	private GameObject mySphere;
	
	Ray mousePosRay = new Ray();
	public Camera myCam;
	public RaycastHit pos;
	

	// Use this for initialization
	void Start ()
	{
		
		MyMover = new Example_3_3_Mover();
		mySphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
		mySphere.transform.localScale = new Vector3(.6F,.2F,.2f);
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
		mySphere.transform.rotation = Quaternion.Euler(MyMover.rotDir);


	}
	


}
