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
	public SpriteRenderer child4;
	public SpriteRenderer child5;
	public SpriteRenderer child6;
	public SpriteRenderer child7;
	public SpriteRenderer child8;
	public SpriteRenderer child9;
	public SpriteRenderer child10;
	public SpriteRenderer child11;
	public SpriteRenderer child12;
	public SpriteRenderer child13;
	public SpriteRenderer child14;
	public SpriteRenderer child15;
	public SpriteRenderer child16;
	public SpriteRenderer child17;
	public SpriteRenderer child18;
	public SpriteRenderer child19;
	public SpriteRenderer child20;
	public SpriteRenderer child21;
	
	
	public BoxCollider2D border;
	
	public const string front = "AboveCharacter";
    public const string back = "BelowCharacter";
	
    void OnTriggerStay2D(Collider2D col){   //changed from OnTriggerEnter2D

        // if(col.gameObject.sortingLayerName == "Character"){}

            if (child && child.sortingLayerName != front) child.sortingLayerName = front;

            if (child2 && child2.sortingLayerName != front) child2.sortingLayerName = front;

            if (child3 && child3.sortingLayerName != front) child3.sortingLayerName = front;

            if (child4 && child4.sortingLayerName != front) child4.sortingLayerName = front;

            if (child5 && child5.sortingLayerName != front) child5.sortingLayerName = front;

            if (child6 && child6.sortingLayerName != front) child6.sortingLayerName = front;

            if (child7 && child7.sortingLayerName != front) child7.sortingLayerName = front;

            if (child8 && child8.sortingLayerName != front) child8.sortingLayerName = front;

            if (child9 && child9.sortingLayerName != front) child9.sortingLayerName = front;

            if (child10 && child10.sortingLayerName != front) child10.sortingLayerName = front;

            if (child11 && child11.sortingLayerName != front) child11.sortingLayerName = front;

            if (child12 && child12.sortingLayerName != front) child12.sortingLayerName = front;

            if (child13 && child13.sortingLayerName != front) child13.sortingLayerName = front;

            if (child14 && child14.sortingLayerName != front) child14.sortingLayerName = front;

            if (child15 && child15.sortingLayerName != front) child15.sortingLayerName = front;

            if (child16 && child16.sortingLayerName != front) child16.sortingLayerName = front;

            if (child17 && child17.sortingLayerName != front) child17.sortingLayerName = front;

            if (child18 && child18.sortingLayerName != front) child18.sortingLayerName = front;

            if (child19 && child19.sortingLayerName != front) child19.sortingLayerName = front;

            if (child20 && child20.sortingLayerName != front) child20.sortingLayerName = front;

            if (child21 && child21.sortingLayerName != front) child21.sortingLayerName = front;
    }
    
    void OnTriggerExit2D(Collider2D col){

        if (child)
            child.sortingLayerName = back;
        if (child2)
            child2.sortingLayerName = back;
        if (child3)
            child3.sortingLayerName = back;
        if (child4)
            child4.sortingLayerName = back;
        if (child5)
            child5.sortingLayerName = back;
        if (child6)
            child6.sortingLayerName = back;
        if (child7)
            child7.sortingLayerName = back;
        if (child8)
            child8.sortingLayerName = back;
        if (child9)
    	    child9.sortingLayerName = back;
        if (child10)
    	    child10.sortingLayerName = back;
        if (child11)
            child11.sortingLayerName = back;
        if (child12)
            child12.sortingLayerName = back;
        if (child13)
            child13.sortingLayerName = back;
        if (child14)
            child14.sortingLayerName = back;
        if (child15)
            child15.sortingLayerName = back;
        if (child16)
            child16.sortingLayerName = back;
        if (child17)
            child17.sortingLayerName = back;
        if (child18)
            child18.sortingLayerName = back;
        if (child19)
            child19.sortingLayerName = back;
        if (child20)
            child20.sortingLayerName = back;
        if (child21)
            child21.sortingLayerName = back;
        
    }

//     void ChangetoFront(SpriteRenderer childN){

//         if (childN && childN.sortingLayerName != front) childN.sortingLayerName = front;
//     }
}
