using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Passableobjects : MonoBehaviour
{
    private Collider2D Border;
    public bool hidden = false;

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

        }
        else
        {

            Border.enabled = true;
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            hidden = true;
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("You are hidden");
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        hidden = false;
        Debug.Log("You are exposed");
    }

}
