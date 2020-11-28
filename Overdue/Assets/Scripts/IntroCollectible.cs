using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCollectible : Collectible
{
    private const string INTRO = "Welcome to the Night Vale Public Library... another nightime victim-guest. Your book that you checked out must be Overdue, triggering the automatic dreamtime teleportation device. You must find the return cart and return your overdue book! After that, you must check out a new book. Grab another book and escape through the main entrance. Beware the libarians! They see your body heat. Hide under tables to escape their gaze! Or better yet find some Librarian Repellant to scare them away for a while! Use your flashlight sparingly! Good luck!";

    public override void Read()
    {
        GameObject.Find(GameObjectNames.Canvas).GetComponent<PauseGame>().Read();
        GameObject.Find(GameObjectNames.PaperText).GetComponent<UnityEngine.UI.Text>().text = INTRO;
    }
}
