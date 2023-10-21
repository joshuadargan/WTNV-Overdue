using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Light_Forward_Fix : MonoBehaviour
{
    // private string playerlayer;
    // [SerializeField] private Light2D light;
    public SpriteRenderer playersprite;
    PlayerMovement PlayerMovement;

    private void Start()
    {
        PlayerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    public void WalkingFoward (){

        if(playersprite.sortingLayerName != "Flashlight_Immune" /*&& PlayerMovement.isCrouching == false*/)
        {
            
            //Debug.Log("before layer change");
            //playersprite.sortingLayerName = "Flashlight_Immune";
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Flashlight_Immune";
            //Debug.Log("after layer change");
        }
    }

    public void NotWalkingForward(){

        if(playersprite.sortingLayerName != "Character" /* && PlayerMovement.isCrouching == false*/)
        {

            //Debug.Log("before layer change");
            //playersprite.sortingLayerName = "Character";
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Character";
           // Debug.Log("after layer change");

        }
    }
}
