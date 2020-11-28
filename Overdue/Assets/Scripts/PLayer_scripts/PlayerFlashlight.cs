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
    public float maxfluid = 100;
    public int FluidConsump;

    public float pickupvalue = 20;

    public AudioSource flashlightSource;
    public AudioSource flashlightOff;
    public AudioSource fluidPickup;

    public PauseGame pauseGame;

    private const float LIBRARIAN_TRIGGER_DISTANCE = 11.5f;
    private const float FLICKER_CHANCE = 0.5f;
    private const float FLICKER_INTENSITY = 0.015625f;
    private const float BASE_INTENSITY = 0.125f;
    private List<GameObject> closeLibrarians;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start fl");
        isFlashlightOn = false;
        flashlightbar.maxValue = maxfluid;
        flashlightbar.value = maxfluid;
        pauseGame = GameObject.Find(GameObjectNames.Canvas).GetComponent<PauseGame>();
        closeLibrarians = new List<GameObject>();
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

        if (flashlightbar.value <= 0)
        {
            isFlashlightOn = false;
            fieldOfView.SetIntensity(0);
        }

        if (isFlashlightOn)
        {
            UseFluid(FluidConsump);
            //Check if there are any librarians close.
            if (closeLibrarians.Count > 0)
            {
                //Find the distance to the closest librarian
                float minDistance = Vector3.Distance(gameObject.transform.position, closeLibrarians[0].transform.position);
                for (int i = 1; i < closeLibrarians.Count; i++)
                {
                    float tempDistance = Vector3.Distance(gameObject.transform.position, closeLibrarians[i].transform.position);
                    if (tempDistance < minDistance)
                        minDistance = tempDistance;
                }
                if (UnityEngine.Random.Range(0, minDistance) < FLICKER_CHANCE)
                {
                    // Flicker lights
                    fieldOfView.SetIntensity(FLICKER_INTENSITY);
                }
                else
                {
                    //Decrease brightness
                    fieldOfView.SetIntensity(BASE_INTENSITY + (1 - BASE_INTENSITY) * (minDistance / LIBRARIAN_TRIGGER_DISTANCE));
                }
            }
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
            if (!fluidPickup.isPlaying)
            {
                fluidPickup.Play();
            }
            flashlightbar.value += pickupvalue;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.Librarian))
        {
            closeLibrarians.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameObjectTags.Librarian))
        {
            for (int i = 0; i < closeLibrarians.Count; i++)
            {
                if (collision.gameObject.name.CompareTo(closeLibrarians[i].name) == 0)
                {
                    closeLibrarians.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
