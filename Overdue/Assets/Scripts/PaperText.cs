using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperText : MonoBehaviour
{
    private static Text paperText;
    // Start is called before the first frame update
    void Start()
    {
        paperText = GetComponent<Text>();
    }

    // Update is called once per frame
    public static void SetPaperText(string lore)
    {
        paperText.text = lore;
    }
}
