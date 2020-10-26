using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatCodeInput : MonoBehaviour
{

    //Assuming that the script is'nt on the Input Object
    private InputField inputField;
    private const string LetThereBeLight = "LetThereBeLight";

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
            }
        }
    }
}
