using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class CS : MonoBehaviour {
    // CS is short for CodeSnippets. This class will gather some useful tiny Code snippets for reuse
    
    public static Vector3 RandVec3DXY(float _min, float _max)
    {
        Vector3 v = new Vector3(UnityEngine.Random.Range(_min, _max), UnityEngine.Random.RandomRange(_min, _max), 0f);
        return v;
    }
    
    public static Vector3 RandVec3(float _min, float _max)
    {
        Vector3 v = new Vector3(UnityEngine.Random.Range(_min, _max), UnityEngine.Random.RandomRange(_min, _max), UnityEngine.Random.RandomRange(_min, _max));
        return v;
    }


    public static Vector3 MousePositionfromCam()
    {
        Ray mousePosRay = new Ray();
        RaycastHit Pos;
        Camera myCamera = Camera.main;
        mousePosRay = myCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(mousePosRay, out Pos);
        Vector3 output = Pos.point;

        return output;
    }

    public static float Constrain(float val, float _min, float _max)
    {
        if (val < _min)
        {
            val = _min;
        }else if (val > _max)
        {
            val = _max;
        }

        return val;
    }

    public static Vector3 ConstrainVector3(Vector3 _vec, float _max)
    {
        Vector3 vec = _vec.normalized;
        float length = _vec.magnitude;
        length = Mathf.Clamp(length, 0, _max);

        return vec * length;
    }

}