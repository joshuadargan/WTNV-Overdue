using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;
using UnityEngine.UI;
using System.Diagnostics;

public class PlayerFlashlight : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    private Boolean isFlashlightOn;
    private float flashlightFluid;

    public Slider flashlightbar;
    public float maxfluid =100;
    public int FluidConsump;


    // Start is called before the first frame update
    void Start()
    {
        isFlashlightOn = false;
        flashlightFluid = 10f;

        flashlightFluid = maxfluid;
        flashlightbar.maxValue = maxfluid;
        flashlightbar.value = maxfluid;
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

        if (flashlightFluid <= 0) {
            isFlashlightOn = false;
            fieldOfView.SetIntensity(0);
        }


        if (isFlashlightOn == true) {

            UseFluid(FluidConsump);
        }

    }

    public void UseFluid(int amount)
    {
        /*if (flashlightFluid >= 0)
        {*/

        
            flashlightFluid -= amount * Time.deltaTime;
            flashlightbar.value = flashlightFluid;

        

           /* Debug.Log("AHHHHHHHHHHHH");
        }
        else
        {
            Debug.Log("Not Enough Fluid");
        }*/


    }

}
