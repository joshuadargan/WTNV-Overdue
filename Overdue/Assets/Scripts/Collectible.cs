using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public static string[] Lore = new string[] {
        "The Biography section contains nothing but 33 copies of the official biography of Helen Hunt",
        "Citizens found themselves in the library by waking up between two shelves in a dizzy haze, unsure of how they got there, and then wandering around, trapped, until they wake with a start in their own beds, covered with sweat, and with a few books they checked out on their nightstand.",
        "Librarian repellent dispensers have been placed throughout the building for the safety of the visitors.",
        "The library is run by a group of malevolent Librarians (who are all named Randall) which the Night Vale citizens are encouraged to be cautious of.",
        "The Librarians offer amnesty for a variety of crimes to anyone willing to visit the library. This is most likely a front, though.",
        "Posters advertising the Summer Reading Program from 2013. All with the tagline 'Catch the flesh - eating reading bacterium!'",
        "You are going to get inside this book, and we are going to close it on you and there is nothing you can do about it",
        "We are going to force you into a good book this summer",
        "During the 2013 program, fourteen students between the ages of 5 and 17 were kidnapped by Librarians and trapped in the library. The number later grew to nearly 100 children and teens before the program officially began that day. It was during this event that Tamika Flynn, 12-years-old at the time, battled Librarians for the first time. Her triumph established her combat and leadership skills, and the severed head of the Librarian served as a reminder of her battle in the summer reading program of 2013",
        "The past is gone, and cannot harm you anymore. And while the future is fast coming for you, it always flinches first and settles in as the gentle present."
        };
    private string text;
    // Start is called before the first frame update
    void Start()
    {
        System.Random rnd = new System.Random();
        text = Lore[rnd.Next(0, Lore.Length)];
    }

    public void Read()
    {
        GameObject.Find(GameObjectNames.Canvas).GetComponent<PauseGame>().Read();
        GameObject.Find(GameObjectNames.PaperText).GetComponent<Text>().text = text;
    }
}
