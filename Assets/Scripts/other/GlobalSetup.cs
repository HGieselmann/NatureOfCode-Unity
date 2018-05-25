using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSetup : MonoBehaviour
{
	private Color ShiffmanRed = new Color(0.84f, 0.035f, 0.35f);
	private Color Dracula = new Color(0.15f,0.15f,0.15f);

	public bool darkWorld = false;

	public Camera myCam;
	// Use this for initialization
	void Start ()
	{
		myCam = Camera.main;
		BGColorSelector();
	}

	

	// Update is called once per frame
	void Update () {
		BGColorSelector();
	}
	
	private void BGColorSelector()
	{
		myCam.clearFlags = CameraClearFlags.SolidColor;
		if (darkWorld == false)
		{
			myCam.backgroundColor = ShiffmanRed;
		}
		else
		{
			myCam.backgroundColor = Dracula;
		}
	}

	public void ToogleDracula()
	{
		if (darkWorld)
		{
			darkWorld = false;
		}
		else
		{
			darkWorld = true;
		}
	}
}
