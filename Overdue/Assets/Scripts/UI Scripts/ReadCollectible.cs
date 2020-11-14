using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadCollectible : MonoBehaviour
{
    [SerializeField] public GameObject collectibleMenuGroup;
    [SerializeField] private bool isPaused;

    public static string lore;

    void Start()
    {
        collectibleMenuGroup.SetActive(false);
        lore = "";
    }

    void Update()
    {
        if (lore.Length == 0)
        {
            if (isPaused)
            {
                Close();
            }
        }
        else if (!isPaused)
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
        isPaused = true;
        PauseGame.IsPaused = true;
    }

    public void Close()
    {
        Time.timeScale = 1f;
        collectibleMenuGroup.SetActive(false);
        isPaused = false;
        PauseGame.IsPaused = false;

    }
}