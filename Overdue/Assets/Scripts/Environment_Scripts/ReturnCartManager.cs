using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnCartManager : MonoBehaviour
{
    public const int NumCarts = 7;
    private static List<GameObject> ReturnCarts = new List<GameObject>();

    public static GameObject ActiveReturnCart { get; private set; }

    public static void AddReturnCart(GameObject rc)
    {
        ActiveReturnCart = rc;
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
                    GameObjectiveUIText.SetObjectiveText("Objective: Return Cart in " + ReturnCarts[i].name.Split('_')[0] + " section");
                    ActiveReturnCart = ReturnCarts[i];
                }
                else
                {
                    ReturnCarts[i].SetActive(false);
                }
            }
        }
    }
}
