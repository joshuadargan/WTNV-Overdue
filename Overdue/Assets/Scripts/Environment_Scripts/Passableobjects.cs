using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Passableobjects : MonoBehaviour
{
    private Collider2D Border;
    public bool hidden = false;
    private bool isUnder = false;

    // Start is called before the first frame update
    void Start()
    {
        Border = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Crouch"))
        {
            Border.enabled = false;
        }
        else if(isUnder == false)
        {
            Border.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col){

        isUnder = true;
    }

    void OnTriggerExit2D(Collider2D col){

        isUnder = false;
    }
}
