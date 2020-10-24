using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;

public class PlayerFlashlight : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    private Boolean isFlashlightOn;
    private float flashlightFluid;

    // Start is called before the first frame update
    void Start()
    {
        isFlashlightOn = false;
        flashlightFluid = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        //Code for the player FOV
        Vector3 targetPosition = UtilsClass.GetMouseWorldPosition();
        Vector3 aimDir = (targetPosition - transform.position).normalized;
        fieldOfView.SetAimDirection(aimDir);
        fieldOfView.SetOrigin(transform.position);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (!isFlashlightOn && flashlightFluid > 0)
            {
                //Flashlight is turned on
                isFlashlightOn = true;
                fieldOfView.SetIntensity(1);
            }
            else
            {
                isFlashlightOn = false;
                fieldOfView.SetIntensity(0);
            }
            
        }
    }
}
