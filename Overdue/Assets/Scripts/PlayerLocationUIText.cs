using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLocationUIText : MonoBehaviour
{
    private static Text locationText;
    // Start is called before the first frame update
    void Start()
    {
        locationText = GetComponent<Text>();
    }

    public static void SetLocationText(string location)
    {
        locationText.text = location;
    }
}
