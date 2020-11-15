using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadCollectible : MonoBehaviour
{
    [SerializeField] public GameObject collectibleMenuGroup;
    [SerializeField] public bool IsPaused;

    void Start()
    {
        IsPaused = false;
        collectibleMenuGroup.SetActive(false);
    }

    public void Read()
    {
        Time.timeScale = 0f;
        collectibleMenuGroup.SetActive(true);
        IsPaused = true;
        PauseGame.IsPaused = true;
    }

    public void Close()
    {
        Debug.Log("Close note");
        Time.timeScale = 1f;
        collectibleMenuGroup.SetActive(false);
        IsPaused = false;
        PauseGame.IsPaused = false;
    }
}