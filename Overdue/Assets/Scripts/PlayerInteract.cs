using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteract : MonoBehaviour
{
    private bool hasReturnedBook;
    private bool hasSecondBook;
    private bool hasExited;
    private bool isCloseToReturnCart;
    private bool isCloseToExit;

    // Start is called before the first frame update
    void Start()
    {
        hasReturnedBook = false;
        hasSecondBook = false;
        isCloseToReturnCart = false;
        isCloseToExit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCloseToReturnCart)
        {
            if (Input.GetKey(KeyCode.E) && !hasReturnedBook)
            {
                ReturnBook();
            }
        }
        else if (isCloseToExit && hasReturnedBook) //TODO: Add 2nd book
        {
            if (Input.GetKey(KeyCode.E) && !hasExited)
            {
                hasExited = true;
                Debug.Log("You win!");
                GameObjectiveUIText.SetObjectiveText("You escaped!");
            }
        }
    }

    private void ReturnBook()
    {
        hasReturnedBook = true;
        GameObjectiveUIText.SetObjectiveText("Objective: Escape!");
        ExitGoal.SetExitLightOn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameObjectTags.ReturnCart))
        {
            isCloseToReturnCart = true;
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.Finish))
        {
            Debug.Log("Enter final");
            isCloseToExit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameObjectTags.ReturnCart))
        {
            isCloseToReturnCart = false;
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.Finish))
        {
            Debug.Log("Exit final");
            isCloseToExit = false;
        }
    }
}
