using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class NewBookBookshelfManager : MonoBehaviour
{
    private List<GameObject> Bookshelves;

    public void Awake()
    {
        Bookshelves = new List<GameObject>();
    }

    public void AddBookshelf(GameObject shelf)
    {
        Bookshelves.Add(shelf);
        shelf.GetComponentInChildren<Light2D>().enabled = false;//GetComponent<Light2D>().enabled = false;
        shelf.GetComponent<CircleCollider2D>().enabled = false;
    }

    public void RemoveBookshelfIfExists(string name)
    {
        Bookshelves.RemoveAll((GameObject x) => x.name.Split('_')[0] == name);
    }

    public void SelectBookshelf()
    {
        System.Random rnd = new System.Random();
        int activeIndex = rnd.Next(0, Bookshelves.Count);
        Bookshelves[activeIndex].GetComponent<CircleCollider2D>().enabled = true;
        Bookshelves[activeIndex].GetComponentInChildren<Light2D>().enabled = true;
        GameObject.Find("ObjectiveText").GetComponent<Text>().text = "Objective: Find a book in " + Bookshelves[activeIndex].name.Split('_')[0] + " section";

    }
}
