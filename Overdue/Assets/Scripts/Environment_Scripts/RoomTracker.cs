using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomTracker : MonoBehaviour
{
    private GameObject Player; 
    private SpriteRenderer ourSprite;
    public float fadeRate = 0.02f;
    private Color targetColor;
    private float target = 1;
    private int a;
    private int b;


    void Start()
    {
        Player = GameObject.Find(GameObjectNames.Player);
        
        ourSprite = gameObject.GetComponent<SpriteRenderer>();

        targetColor = ourSprite.color;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (target < 1){
            target = target + fadeRate;                 //move up the target estimate

            targetColor.a = Mathf.Lerp(a, b, target);   // set estimate

            ourSprite.color = targetColor;              //set color
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){

            a = 1;
            b = 0;
            target = 0;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){

            a = 0;
            b = 1;
            target = 0;
        }

    }
}
