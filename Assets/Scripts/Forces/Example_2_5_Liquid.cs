using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;



public class Example_2_5_Liquid : MonoBehaviour {
	
	public float x,y,w,h;
	public float c;
	public GameObject LiquidGameObject;
	
	// Call me Captn Constructor
	public Example_2_5_Liquid(float x_, float y_, float w_, float h_, float c_)
	{
		x = x_;
		y = y_;
		w = w_;
		h = h_;
		c = c_;
		
	}

	public void displayLiquid()
	{
		LiquidGameObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
		LiquidGameObject.transform.position = new Vector3(x, y/2, 0f);
		LiquidGameObject.transform.localScale = new Vector3(w, h/2, 0f);
	}
}
