using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class NewBookBookshelfManager : MonoBehaviour
{
    private static List<GameObject> Bookshelves = new List<GameObject>();

    public static void AddBookshelf(GameObject shelf)
    {
        Bookshelves.Add(shelf);
        shelf.GetComponentInChildren<Light2D>().enabled = false;//GetComponent<Light2D>().enabled = false;
        shelf.GetComponent<CircleCollider2D>().enabled = false;
    }

    public static void RemoveBookshelfIfExists(string name)
    {
        Bookshelves.RemoveAll((GameObject x) => x.name.Split('_')[0] == name);
    }

    public static void SelectBookshelf()
    {
        System.Random rnd = new System.Random();
        int activeIndex = rnd.Next(0, Bookshelves.Count);
        Bookshelves[activeIndex].GetComponent<CircleCollider2D>().enabled = true;
        Bookshelves[activeIndex].GetComponentInChildren<Light2D>().enabled = true;
        GameObjectiveUIText.SetObjectiveText("Objective: Find a book in " + Bookshelves[activeIndex].name.Split('_')[0] + " section");

    }
}
