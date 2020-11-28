using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective_trigger : MonoBehaviour
{
	//Collider2D child;
	//Collider2D child2;
	//Collider2D child3;
	
	public SpriteRenderer child;
	public SpriteRenderer child2;
	public SpriteRenderer child3;
	
	public BoxCollider2D border;
	
	public const string front = "Character";
    public const string back = "BelowCharacter";
	
    void OnTriggerEnter2D(){
        if (child)
    	    child.sortingLayerName = front;
        if (child2)
    	    child2.sortingLayerName = front;
        if (child3)
            child3.sortingLayerName = front;
    }
    
    void OnTriggerExit2D(){
        if (child)
            child.sortingLayerName = back;
        if (child2)
            child2.sortingLayerName = back;
        if (child3)
            child3.sortingLayerName = back;
    }
}
