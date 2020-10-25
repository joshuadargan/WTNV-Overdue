using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StamBarFade : MonoBehaviour
{
	
	public CanvasGroup stambar;
	public Slider staminabar;
	private float currentstamina;
	private float maxstamina;
	
    // Start is called before the first frame update
    void Start()
    {
        maxstamina = staminabar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
    	currentstamina = staminabar.value;
    	
    	if((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && Input.GetButton("Sprint")){			//Experimental Fade if function
        	StartCoroutine(AppearCanvasGroup(1));
    	}else if(currentstamina == staminabar.maxValue){
    		
    		StartCoroutine(FadeCanvasGroup(1));
        }
    	
    	if(stambar.alpha == 1) StopCoroutine(AppearCanvasGroup(1));
    	if(stambar.alpha <= .1) StopCoroutine(FadeCanvasGroup(1));
         
    }

    public IEnumerator FadeCanvasGroup(float rate){
    	
    	/*float _timeStartedLerping = Time.time;
    	float timeSinceStarted = Time.time - _timeStartedLerping;
    	float percentageComplete = timeSinceStarted / lerptime;
    	
    	while(true){
    	 	timeSinceStarted = Time.time - _timeStartedLerping;
    	 	percentageComplete = timeSinceStarted / lerptime;
    	 	
    	 	float currentValue = Mathf.Lerp(start, end, percentageComplete);
    	 	
    	 	cg.alpha = currentValue;
    	 	
    	 	if (percentageComplete >= 1) break;
    		
    	 	yield return new WaitForEndOfFrame();
    	}
    	print("done");*/
    	
    	yield return new WaitForSeconds(1);
    	for (float ft = stambar.alpha; ft > 0; ft -= (rate/100))
    	{
        	stambar.alpha = ft;
        	yield return null;
    	}
    	
    }
    
    public IEnumerator AppearCanvasGroup(float rate){
    	
    	for (float ft = stambar.alpha; ft < 1; ft += (rate/60)) 
    	{
        	stambar.alpha = ft;
        	yield return null;
    	}
    	
    }

}
