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
	
	public const string front = "AboveCharacter";
    public const string back = "BelowCharacter";
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(){
    	child.sortingLayerName = front;
    	child2.sortingLayerName = front;
    	child3.sortingLayerName = front;
    }
    
    void OnTriggerExit2D(){
    	child.sortingLayerName = back;
    	child2.sortingLayerName = back;
    	child3.sortingLayerName = back;
    }
}
