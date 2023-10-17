using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Light_Forward_Fix : MonoBehaviour
{
    // private string playerlayer;
    // [SerializeField] private Light2D light;
    public SpriteRenderer playersprite; 

    public void WalkingFoward (){

        if(playersprite.sortingLayerName != "Forward_Light_Fix"){
            
            Debug.Log("before layer change");
            playersprite.sortingLayerName = "Forward_Light_Fix";
            Debug.Log("after layer change");
        }
    }

    public void NotWalkingForward(){

        if(playersprite.sortingLayerName == "Forward_Light_Fix"){
            
            playersprite.sortingLayerName = "Character";
        }
    }
}
