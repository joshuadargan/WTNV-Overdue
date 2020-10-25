using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnCartManager : MonoBehaviour
{
    public const int NumCarts = 7;
    private static List<GameObject> ReturnCarts = new List<GameObject>();

    public static void AddReturnCart(GameObject rc)
    {
        
        ReturnCarts.Add(rc);
        Debug.Log("Cart Addded " + ReturnCarts.Count + " " +  rc.name);
        //Randomly select a cart to become the active cart
        if (ReturnCarts.Count >= NumCarts)
        {
            System.Random rnd = new System.Random();
            int activeIndex = rnd.Next(0, ReturnCarts.Count);
            for (int i = 0; i < ReturnCarts.Count; i++)
            {
                if (activeIndex == i)
                {
                    Debug.Log("Objective Set");
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
