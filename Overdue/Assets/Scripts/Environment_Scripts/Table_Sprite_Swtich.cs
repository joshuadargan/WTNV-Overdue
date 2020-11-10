using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table_Sprite_Swtich : MonoBehaviour
{
	
	public GameObject Object;
   // private Collider2D trigger;
	
    public SpriteRenderer player;
	
    // Start is called before the first frame update
    void Start()
    {
       // trigger = GetComponent<CapsuleCollider2D>();
        //trigger.enabled = !trigger.enabled;
    }

    // Update is called once per frame
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
            Object.SetActive(true);
            
     	 }
    	
    }
    
    void OnTriggerExit2D(Collider2D character){
    	 if(character.tag == "Player"){
            player.enabled = true;
            Object.SetActive(false);
            
        }
    	
    }
}
