using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table_Sprite_Swtich : MonoBehaviour
{
	
	public GameObject Object;
	
	public const string crouch_layer = "Crouching";
	public Spriterender player;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D player){
    	 if(player.tag == "Player" && player.sortingLayerName == crouch_layer){
         	Object.SetActive(true);
         	
         	
     	}
    	
    }
    
    void OnTriggerExit2D(Collider2D player){
    	 if(player.tag == "Player"){
         	Object.SetActive(false);
     	}
    	
    }
}
