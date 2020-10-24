using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteract : MonoBehaviour
{
    private bool hasReturnedBook;
    private bool hasSecondBook;
    private bool isCloseToReturnCart;

    // Start is called before the first frame update
    void Start()
    {
        hasReturnedBook = false;
        hasSecondBook = false;
        isCloseToReturnCart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCloseToReturnCart)
        {
            if (Input.GetKey(KeyCode.E) && !hasReturnedBook)
            {
                hasReturnedBook = true;
                //TODO: Have it do something for the player to let them know that they returned the book
                GameObjectiveUIText.SetObjectiveText("Objective: Escape!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Enter");
        if (collision.gameObject.CompareTag(GameObjectTags.ReturnCart))
        {
            isCloseToReturnCart = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Exit");
        if (collision.gameObject.CompareTag(GameObjectTags.ReturnCart))
        {
            isCloseToReturnCart = false;
        }
    }
}
