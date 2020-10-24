using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectiveUIText : MonoBehaviour
{
    private static Text objectiveText;
    // Start is called before the first frame update
    void Start()
    {
        objectiveText = GetComponent<Text>();
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public static void SetObjectiveText(string objective)
    {
        objectiveText.text = objective;
    }
}
