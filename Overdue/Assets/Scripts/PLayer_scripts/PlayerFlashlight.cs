using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;
using UnityEngine.UI;

public class PlayerFlashlight : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    private Boolean isFlashlightOn;

    public Slider flashlightbar;
    public float maxfluid =100;
    public int FluidConsump;

    public float pickupvalue = 20;

    public AudioSource flashlightSource;
    public AudioSource flashlightOff;
    public AudioSource fluidPickup;

    public PauseGame pauseGame;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start fl");
        isFlashlightOn = false;
        flashlightbar.maxValue = maxfluid;
        flashlightbar.value = maxfluid;
        pauseGame = GameObject.Find(GameObjectNames.Canvas).GetComponent<PauseGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseGame.isPaused)
        {
            return;
        }
        //Code for the player FOV
        Vector3 targetPosition = UtilsClass.GetMouseWorldPosition();
        Vector3 aimDir = (targetPosition - transform.position).normalized;
        fieldOfView.SetAimDirection(aimDir);
        fieldOfView.SetOrigin(transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            if (!isFlashlightOn && flashlightbar.value > 0)
            {
                //Flashlight is turned on
                isFlashlightOn = true;
                fieldOfView.SetIntensity(1);
                flashlightSource.Play();

            }
            else
            {
                isFlashlightOn = false;
                fieldOfView.SetIntensity(0);
                flashlightOff.Play();
            }

        }

        if (flashlightbar.value <= 0) {
            isFlashlightOn = false;
            fieldOfView.SetIntensity(0);
        }

        if (isFlashlightOn == true) {

            UseFluid(FluidConsump);
        }


    }

    public void UseFluid(int amount)
    {
        flashlightbar.value -= amount * Time.deltaTime;
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("light_pickup"))
        {
          if(!fluidPickup.isPlaying)
          {
            fluidPickup.Play();
          }
        	flashlightbar.value += pickupvalue;
            Destroy(collision.gameObject);
        }
    }

}
