using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatCodeInput : MonoBehaviour
{

    //Assuming that the script is'nt on the Input Object
    private InputField inputField;
    private const string LetThereBeLight = "LetThereBeLight";
    private const string Invincible = "Invincible";
    private const string DebugMode = "DebugMode";
    private const string Repel = "Repel";

    public static bool invincible = false;
    public static bool repel = false;
    //TODO: DEFAULT THIS TO FALSE
    public static bool debugMode = false;

    // Start is called before the first frame update
    void Start()
    {
        inputField = this.GetComponent<InputField>();
    }

    private void Update()
    {
        if (inputField)
        {
            if (!string.IsNullOrEmpty(inputField.text))
            {
                if (inputField.text.CompareTo(LetThereBeLight) == 0)
                {
                    GlobalLightCheat.ToggleGlobalLightOn();
                }
                else if (inputField.text.CompareTo(Invincible) == 0)
                {
                    invincible = true;
                }
                else if (inputField.text.CompareTo(Repel) == 0)
                {
                    repel = true;
                }
                else if (inputField.text.CompareTo(DebugMode) == 0)
                {
                    debugMode = true;
                }
            }
        }
    }
}
