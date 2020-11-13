﻿using System;
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
    private bool isCloseToNewBookshelf;

    // Start is called before the first frame update
    void Start()
    {
        hasReturnedBook = false;
        hasSecondBook = false;
        isCloseToReturnCart = false;
        isCloseToExit = false;
        isCloseToNewBookshelf = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCloseToReturnCart)
        {
            if (Input.GetKey(KeyCode.E) && !hasReturnedBook)
            {
                if (CheatCodeInput.debugMode)
                    Debug.Log("Book Returned");
                ReturnBook();
            }
        }
        else if (isCloseToNewBookshelf)
        {
            if (Input.GetKey(KeyCode.E) && hasReturnedBook && !hasSecondBook)
            {
                if (CheatCodeInput.debugMode)
                    Debug.Log("New book gotten");
                GetNewBook();
            }
        }
        else if (isCloseToExit && hasReturnedBook && hasSecondBook)
        {
            if (Input.GetKey(KeyCode.E) && !hasExited)
            {
                hasExited = true;
                if (CheatCodeInput.debugMode)
                    Debug.Log("You win!");
                GameObjectiveUIText.SetObjectiveText("You escaped!");
            }
        }
    }

    private void ReturnBook()
    {
        hasReturnedBook = true;
        NewBookBookshelfManager.RemoveBookshelfIfExists(ReturnCartManager.ActiveReturnCart.name.Split('_')[0]);
        NewBookBookshelfManager.SelectBookshelf();
    }

    private void GetNewBook()
    {
        hasSecondBook = true;
        GameObjectiveUIText.SetObjectiveText("Objective: Escape!");
        ExitGoal.SetExitLightOn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameObjectTags.ReturnCart))
        {
            isCloseToReturnCart = true;
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.NewBook))
        {
            isCloseToNewBookshelf = true;
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.Finish))
        {
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
        else if (collision.gameObject.CompareTag(GameObjectTags.NewBook))
        {
            isCloseToNewBookshelf = false;
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.Finish))
        {
            isCloseToExit = false;
        }
    }
}
