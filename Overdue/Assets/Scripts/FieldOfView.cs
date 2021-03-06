﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.Experimental.Rendering.Universal;

public class FieldOfView : MonoBehaviour
{
    Vector3 origin;
    private float startingAngle;
    private float fov;

    private Light2D lt;


    // Start is called before the first frame update
    private void Start()
    {
        origin = Vector3.zero;
        startingAngle = 0f;
        lt = GetComponent<Light2D>();
        lt.intensity = 0;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        lt.transform.position = origin;
        lt.transform.rotation = Quaternion.Euler(0, 0, startingAngle);
    }

    public void SetOrigin (Vector3 origin)
    {
        this.origin = origin + new Vector3(0,0,0);
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        this.startingAngle = UtilsClass.GetAngleFromVectorFloat(aimDirection) - 90f;
    }

    public void SetIntensity(float intensity)
    {
        lt.intensity = intensity;
    }
    
}

