using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCollectible : Collectible
{
    string stuff = "During the 2013 program, fourteen students between the ages of 5 and 17 were kidnapped by Librarians and trapped in the library.The number later grew to nearly 100 children and teens before the program officially began that day. It was during this event that Tamika Flynn, 12-years-old at the time, battled Librarians for the first time.Her triumph established her combat and leadership skills, and the severed head of the Librarian served as a reminder of her battle.";
    private const string INTRO = "Welcome to the Night Vale Public Library... another nightime victim-guest. Your book that you checked out must be Overdue, triggering the automatic dreamtime teleportation device. You must find the return cart and return your overdue book! After that, you must check out a new book. Grab another book and escape through the main entrance. Beware the libarians! They see your body heat. Hide under tables to escape their gaze! Or better yet find some Librarian Repellant to scare them away for a while! Use your flashlight sparingly! Good luck!";
    // Start is called before the first frame update

    public override void Read()
    {
        GameObject.Find(GameObjectNames.Canvas).GetComponent<PauseGame>().Read();
        GameObject.Find(GameObjectNames.PaperText).GetComponent<UnityEngine.UI.Text>().text = INTRO;
    }
}
