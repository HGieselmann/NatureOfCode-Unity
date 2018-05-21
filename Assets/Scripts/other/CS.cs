using System;
using System.Collections;
using System.Collections.Generic;
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


}
