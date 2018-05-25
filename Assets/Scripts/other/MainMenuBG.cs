using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainMenuBG : MonoBehaviour
{

    public static int NOfColumns = 50;
    public static int NOfRows = 40;

    public GameObject[] Quads = new GameObject[NOfColumns * NOfRows];
    public float speed = 0;
    public float perlinScaler = 0.1f;
    public Vector3 mousePosOld = new Vector3(0,0,0);
    public Vector3 mousePos;
    public Renderer rend;
    public Material DarkGrey;

    public void Start()
    {
        createGrid();
    }

    private void Update()
    {
        Debug.Log(Quads.Length);
        mousePos = CS.MousePositionfromCam();
        Vector3 MouseDistance = mousePosOld - mousePos;
        float disturb = MouseDistance.magnitude;
        MoveGrid(1f + disturb*5);
        mousePosOld = mousePos;
    }

    public void createGrid()
    {
        for (int i = 0; i < Quads.Length; i++)
        {
            int a = (int) (i / NOfColumns);
            int off = a * NOfColumns;
            
            Quads[i] = GameObject.CreatePrimitive(PrimitiveType.Quad);
            Quads[i].transform.position = new Vector3((i - off), a, 0)*.5f;
            Quads[i].transform.localScale = new Vector3(0.4f, 0.075f, 1);
            rend = Quads[i].GetComponent<Renderer>();
            rend.material = DarkGrey;


        }
    }

    public void MoveGrid(float _inc)
    {
        speed += _inc * Time.deltaTime;
        
        
        
        for (int i = 0; i < Quads.Length; i++)
        {
            int a = (int) (i / NOfColumns);
            int off = a * NOfColumns;
            float myPerlin = Mathf.PerlinNoise((i - off + speed)*perlinScaler, (a + speed)*perlinScaler) * 360;
            Quads[i].transform.localRotation = Quaternion.Euler(0,0, myPerlin);
            
        }
    }

    
}
