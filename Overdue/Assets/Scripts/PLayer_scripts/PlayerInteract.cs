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
        else if (collision.gameObject.CompareTag(GameObjectTags.Fantasy))
        {
            PlayerLocationUIText.SetLocationText("Current Location: Fantasy Section");
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.SciFi))
        {
            PlayerLocationUIText.SetLocationText("Current Location: SciFi Section");
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.Kids))
        {
            PlayerLocationUIText.SetLocationText("Current Location: Kids Section");
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.TownHistory))
        {
            PlayerLocationUIText.SetLocationText("Current Location: Town History Section");
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.AutoBio))
        {
            PlayerLocationUIText.SetLocationText("Current Location: Biography Section");
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.Mystery))
        {
            PlayerLocationUIText.SetLocationText("Current Location: Mystery Section");
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.Romance))
        {
            PlayerLocationUIText.SetLocationText("Current Location: Romance Section");
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.MainEntrance))
        {
            PlayerLocationUIText.SetLocationText("Current Location: Entrance Lobby");
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
