﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerInteract : MonoBehaviour
{
    public bool hasReturnedBook { get; private set; }
    public bool hasSecondBook { get; private set; }
    public bool hasExited { get; private set; }
    public bool isCloseToReturnCart { get; private set; }
    public GameObject closeReturnCart { get; private set; }
    public bool isCloseToExit { get; private set; }
    public bool isCloseToNewBookshelf { get; private set; }
    public GameObject closeNewBookshelf { get; private set; }
    public bool isCloseToCollectible { get; private set; }
    public GameObject closeCollectible { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        hasReturnedBook = false;
        hasSecondBook = false;
        isCloseToReturnCart = false;
        closeReturnCart = null;
        isCloseToExit = false;
        isCloseToNewBookshelf = false;
        closeNewBookshelf = null;
        isCloseToCollectible = false;
        closeCollectible = null;
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
                gameObject.GetComponent<EndScreenManager>().Win();
                GameObjectiveUIText.SetObjectiveText("You escaped!");
            }
        }
        else if (isCloseToCollectible && closeCollectible)
        {
            if (Input.GetKey(KeyCode.E))
            {
                isCloseToCollectible = false;
                closeCollectible.SetActive(false);
                closeCollectible = null;
            }
        }
    }

    private void ReturnBook()
    {
        hasReturnedBook = true;
        NewBookBookshelfManager.RemoveBookshelfIfExists(ReturnCartManager.ActiveReturnCart.name.Split('_')[0]);
        NewBookBookshelfManager.SelectBookshelf();
        closeReturnCart.GetComponentInChildren<Light2D>().enabled = false;
    }

    private void GetNewBook()
    {
        hasSecondBook = true;
        GameObjectiveUIText.SetObjectiveText("Objective: Escape!");
        ExitGoal.SetExitLightOn();
        closeNewBookshelf.GetComponentInChildren<Light2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameObjectTags.ReturnCart))
        {
            isCloseToReturnCart = true;
            closeReturnCart = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.NewBook))
        {
            isCloseToNewBookshelf = true;
            closeNewBookshelf = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.Finish))
        {
            isCloseToExit = true;
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.Collectible))
        {
            isCloseToCollectible = true;
            closeCollectible = collision.gameObject;
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
            closeReturnCart = null;
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.NewBook))
        {
            isCloseToNewBookshelf = false;
            closeNewBookshelf = null;
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.Finish))
        {
            isCloseToExit = false;
        }
        else if (collision.gameObject.CompareTag(GameObjectTags.Collectible))
        {
            isCloseToCollectible = false;
            closeCollectible = null;
        }
    }
}
