using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table_Sprite_Swtich : MonoBehaviour
{
	public GameObject hiddenVariant;
    public GameObject OGVariant;
   // private Collider2D trigger;
    public SpriteRenderer player;
	
    void Start()
    {
       // trigger = GetComponent<CapsuleCollider2D>();
        //trigger.enabled = !trigger.enabled;
    }

    void Update()
    {
        /*if (player.sortingLayerName == "Crouching")
        {
            trigger.enabled = trigger.enabled;
        }
        else if (player.sortingLayerName == "Character"){
            trigger.enabled = !trigger.enabled;
        }*/
    }
    
    void OnTriggerEnter2D(Collider2D character){
    	 if(character.tag == "Player" /*&& player.sortingLayerName == crouch_layer*/){
            player.enabled = false;
            hiddenVariant.SetActive(true);
            OGVariant.SetActive(false);
            OGVariant.GetComponent<SpriteRenderer>().sortingLayerName = "Flashlight_Immune";
     	 }
    	
    }
    
    void OnTriggerExit2D(Collider2D character){
    	 if(character.tag == "Player"){
            player.enabled = true;
            hiddenVariant.SetActive(false);
            OGVariant.SetActive(true);
        }
    	
    }
}
