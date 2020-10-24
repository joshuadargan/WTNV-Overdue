using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnCartManager : MonoBehaviour
{
    private static List<GameObject> ReturnCarts;
    public const int NumCarts = 7;

    public static void AddReturnCart(GameObject rc)
    {
        ReturnCarts.Add(rc);
        //Randomly select a cart to become the active cart
        if (ReturnCarts.Count >= NumCarts)
        {
            System.Random rnd = new System.Random();
            int activeIndex = rnd.Next(0, ReturnCarts.Count);
            for (int i = 0; i < ReturnCarts.Count; i++)
            {
                if (activeIndex == i)
                {
                    ReturnCarts[i].SetActive(true);
                    GameObjectiveUIText.SetObjectiveText("Current Objective: " + ReturnCarts[i].name);
                }
                else
                {
                    ReturnCarts[i].SetActive(false);
                }
            }
        }
    }
}
