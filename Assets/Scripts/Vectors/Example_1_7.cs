using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Example_1_7 : MonoBehaviour {
	
	public Example_1_7_Mover MyMover;
	public Transform mySphere;
	

	// Use this for initialization
	void Start ()
	{
		MyMover = new Example_1_7_Mover();
		//mySphere = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
		MyMover.UpdatePosition();
		MyMover.CheckEdges();
		mySphere.position = new Vector3(MyMover.location.x, MyMover.location.y, 0f);


	}
	


}
