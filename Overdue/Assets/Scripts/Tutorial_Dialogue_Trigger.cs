using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Dialogue_Trigger : MonoBehaviour
{
    private string text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual void Read()
    {
        GameObject.Find(GameObjectNames.Canvas).GetComponent<PauseGame>().Read();
        GameObject.Find(GameObjectNames.PaperText).GetComponent<Text>().text = text;
    }
}
