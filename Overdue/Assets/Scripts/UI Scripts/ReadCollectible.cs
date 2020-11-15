using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadCollectible : MonoBehaviour
{
    [SerializeField] public GameObject collectibleMenuGroup;
    [SerializeField] public static bool IsPaused;

    public static string lore;

    void Start()
    {
        IsPaused = false;
        collectibleMenuGroup.SetActive(false);
        lore = "";
    }


    void Update()
    {
        if (lore.Length == 0)
        {
            if (IsPaused)
            {
                Close();
            }
        }
        else if (!IsPaused)
        {
            Read();
        }
    }

    public static void SetLore(string l)
    {
        lore = l;
    }

    public void Read()
    {
        Time.timeScale = 0f;
        collectibleMenuGroup.SetActive(true);
        IsPaused = true;
        PauseGame.IsPaused = true;
        PaperText.SetPaperText(lore);
    }

    public void Close()
    {
        Debug.Log("Close note");
        Time.timeScale = 1f;
        collectibleMenuGroup.SetActive(false);
        IsPaused = false;
        PauseGame.IsPaused = false;
        SetLore("");


    }
}