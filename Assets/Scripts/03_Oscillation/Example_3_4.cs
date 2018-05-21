using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example_3_4 : MonoBehaviour
{
	//private Toggle Tgl_Spiralize;
	//Arbatrary decision to size the Canvas we want our world to live in
	private float CSizeX = 16;
	private float CSizeY = 9;
		

	private GameObject sphere;
	public float r; // distance from the origin
	private float theta = 0; // angle in polar coordiante system
	public float thetaIncrease = 0.3f;

	private float x; // Our Cartesian Coordiantes
	private float y;
	

	// Use this for initialization
	void Start () {
		//Tgl_Spiralize = GetComponent<Toggle>();
		sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		ToCartesian();
		sphere.transform.position = new Vector3(x + CSizeX/2 , y + CSizeY/2 , 0f);
		theta += thetaIncrease * Time.deltaTime;

	}

	private void ToCartesian()
	{
		x = r * Mathf.Cos(theta);
		y = r * Mathf.Sin(theta);

	}
}
