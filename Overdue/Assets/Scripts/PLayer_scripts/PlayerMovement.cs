using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 speed = new Vector2(5,5);
    public Vector2 sprintspeed = new Vector2 (10,10);
    public Vector2 crouchspeed = new Vector2 (2,2);
    
    public bool usesRigidbody;
    public float ControllerMultiplier = 0.5f;

    Vector3 movement;

    public Rigidbody2D rb;


    public Slider staminabar;
    [SerializeField] private int maxstamina = 100;
    private float currentstamina;
    [SerializeField] private int staminaconsump = 1;

    private WaitForSeconds regenTick = new WaitForSeconds(.1f);
    private Coroutine regen;

    public const string stand_layer = "Character";
    public const string crouch_layer = "Crouching";
    public bool isCrouching;
    private SpriteRenderer sprite;

    public bool IsHiddenUnderTable { get; private set; } = false;
    public bool IsUnderTable { get; private set; } = false;

    public AudioSource walkSound;
    public AudioSource heavyBreathing;
    public AudioSource runSound;
   // public AudioSource noiseSound;

    public static bool isMakingNoise = false;

    // Start is called before the first frame update
    void Start()
    {
        currentstamina = maxstamina;
    	staminabar.maxValue = maxstamina;
    	staminabar.value = maxstamina;

        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(staminabar.value == staminabar.maxValue)
        {
            heavyBreathing.Stop();
        }
        //Movement Code
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //rb.velocity = new Vector2(inputX, inputY);

        Crouching();

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) {

            if (Input.GetButton("Crouch") || IsUnderTable == true){
                //movement = new Vector3(crouchspeed.x * inputX, crouchspeed.y * inputY, 0);

                if (usesRigidbody == true)
                {
                    rb.velocity = new Vector3(crouchspeed.x * inputX, crouchspeed.y * inputY, 0);           //uses rigidbody  RIGIDBODY USES AND CONTROLLER USES CANNOT COEXIST
                }
                else
                {
                    gameObject.transform.Translate(new Vector3(crouchspeed.x * inputX, crouchspeed.y * inputY, 0) * Time.deltaTime * ControllerMultiplier);        //uses transform
                }                                                                                                                                            
        	}
        	else if (Input.GetButton("Sprint") && currentstamina > 0){
                //movement = new Vector3(sprintspeed.x * inputX, sprintspeed.y * inputY, 0);

                if (usesRigidbody == true)
                {
                    rb.velocity = new Vector3(sprintspeed.x * inputX, sprintspeed.y * inputY, 0);           //uses rigidbody
                }
                else
                {
                    gameObject.transform.Translate(new Vector3(sprintspeed.x * inputX, sprintspeed.y * inputY, 0) * Time.deltaTime * ControllerMultiplier); //uses transform
                }

                UseStamina(staminaconsump);
                IsHiddenUnderTable = false;
                if(!runSound.isPlaying)
                {
                    runSound.Play();
                }
            }
            else{
                //movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

                if (usesRigidbody == true)
                {
                    rb.velocity = new Vector3(speed.x * inputX, speed.y * inputY, 0);                       //uses rigidbody
                }
                else
                {
                    gameObject.transform.Translate(new Vector3(speed.x * inputX, speed.y * inputY, 0) * Time.deltaTime * ControllerMultiplier);        //uses controller
                }


                IsHiddenUnderTable = false;
                if(!walkSound.isPlaying)
                {
                    walkSound.Play();
                }
            }
        }else{
        	rb.velocity = new Vector3(0, 0, 0);                                            //uses rigidbody
            walkSound.Stop();
            runSound.Stop();

        }

        //movement *= Time.deltaTime;

        //transform.Translate(movement);
    }

    public void UseStamina(int amount) {
    	if(currentstamina>= 0) {
    		currentstamina -= amount*Time.deltaTime;
    		staminabar.value = currentstamina;

    		if(regen != null) 	StopCoroutine(regen);

    		regen = StartCoroutine(RegenStamina());
    	} else {
            if (CheatCodeInput.debugMode)
                Debug.Log("Not Enough Stamina");
    	}
    }

    private IEnumerator RegenStamina() {
    	yield return new WaitForSeconds(2);

    	while(currentstamina < maxstamina) {
    		currentstamina += maxstamina / 100;
    		staminabar.value = currentstamina;
            if(!heavyBreathing.isPlaying)
            {
                heavyBreathing.Play();
            }
    		yield return regenTick;
    		}

    	regen = null;
    }

    private void Crouching() {
        if (Input.GetButton("Crouch")) {
            isCrouching = true;
         //   sprite.sortingLayerName = crouch_layer;           //disabling as a test
            if (IsUnderTable)
            {
                IsHiddenUnderTable = true;
            }
            else
            {
                IsHiddenUnderTable = false;
            }
        } else if (IsUnderTable == true){ 
            
            IsHiddenUnderTable = true;
        
        }else {
            //sprite.sortingLayerName = stand_layer;
            isCrouching = false;
            IsHiddenUnderTable = false;
        }

    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag(GameObjectTags.Table) && sprite.sortingLayerName == crouch_layer)
    //     {
    //         if (CheatCodeInput.debugMode) Debug.Log("You are hidden"); //this may be broken

    //         IsUnderTable = true;
    //         gameObject.layer = 2;
    //     }
    // }

    private void OnTriggerStay2D(Collider2D col){

        if((col.gameObject.tag == "Table" && isCrouching == true) || CheatCodeInput.debugMode){

            IsUnderTable = true;
            gameObject.layer = 2;
        }

        if (col.gameObject.tag == "Noisy" && isCrouching == false && rb.velocity != Vector2.zero)      //checks to see if the Player is walking on something noisy
        {

            if (isMakingNoise == false) { 
                
                isMakingNoise = true;
                //Debug.Log("is making noise");
            
            }     //modifies the script on the SoundTarget gameobject
            
            //if(noiseSound.isPlaying == false) noiseSound.Play();
                //play loud crunch sound
        }
        else {

            isMakingNoise = false;      
            //noiseSound.Stop();
                //play quieter crunch sound
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameObjectTags.Table))
        {
            if (CheatCodeInput.debugMode)
                Debug.Log("You are exposed");
            IsUnderTable = false;
            gameObject.layer = 9;
        }
    }


    // private void OnCollisionEnter2D(Collision2D col){        //when the Player hits something, reset velocity
    //     Debug.Log("oops!");
    //    rb.velocity = new Vector3(0, 0, 0);  
    // }

}
