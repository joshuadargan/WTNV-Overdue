using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadCollectible : MonoBehaviour
{
    [SerializeField] public GameObject collectibleMenuGroup;
    [SerializeField] private bool isPaused;

    void Start()
    {
        collectibleMenuGroup.SetActive(false);
    }

    void Update()
    {
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        collectibleMenuGroup.SetActive(true);
        isPaused = true;
        PauseGame.IsPaused = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        collectibleMenuGroup.SetActive(false);
        isPaused = false;
        PauseGame.IsPaused = false;
    }
}