using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 speed = new Vector2(5,5);
    public Vector2 sprintspeed = new Vector2 (10,10);
    public Vector2 crouchspeed = new Vector2 (2,2);
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
    private SpriteRenderer sprite;


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
        //Movement Code
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        
        //rb.velocity = new Vector2(inputX, inputY);

        Crouching();

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")){

            if (Input.GetButton("Crouch")){
        		//movement = new Vector3(crouchspeed.x * inputX, crouchspeed.y * inputY, 0);
        		rb.velocity = new Vector3(crouchspeed.x * inputX, crouchspeed.y * inputY, 0);
        		}
        	else if (Input.GetButton("Sprint") && currentstamina > 0){
       			//movement = new Vector3(sprintspeed.x * inputX, sprintspeed.y * inputY, 0);
       			rb.velocity = new Vector3(sprintspeed.x * inputX, sprintspeed.y * inputY, 0);
       			
       			UseStamina(staminaconsump);
            }
            else{
        		//movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
        		rb.velocity = new Vector3(speed.x * inputX, speed.y * inputY, 0);
            }
        }else{
        	rb.velocity = new Vector3(0, 0, 0);
        }
        //movement *= Time.deltaTime;
        
        //transform.Translate(movement); 
    }
    
    public void UseStamina(int amount){
    	if(currentstamina>= 0){
    		currentstamina -= amount*Time.deltaTime;
    		staminabar.value = currentstamina;
    		
    		if(regen != null) 	StopCoroutine(regen);
    		
    		regen = StartCoroutine(RegenStamina());
    	}else{
    		Debug.Log("Not Enough Stamina");
    	}
    }
    	
    private IEnumerator RegenStamina(){
    	yield return new WaitForSeconds(2);
    	
    	while(currentstamina < maxstamina){
    		currentstamina += maxstamina / 100;
    		staminabar.value = currentstamina;
    		yield return regenTick;
    		}
    	
    	regen = null;
    	}

    private void Crouching() {
        if (Input.GetButton("Crouch")) { 
            sprite.sortingLayerName = crouch_layer;
        
        }else{
            sprite.sortingLayerName = stand_layer;
        }
            
    }
    	

}
