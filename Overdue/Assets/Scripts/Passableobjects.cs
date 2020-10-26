using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passableobjects : MonoBehaviour
{
    private Collider2D Border;

    // Start is called before the first frame update
    void Start()
    {
        Border = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Crouch"))
        {
            Border.enabled = false;
       
        }else{

            Border.enabled = true;
        }


        
    }
}
