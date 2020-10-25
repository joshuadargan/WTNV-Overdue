using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public KeyCode pauseKeyCode;
    [SerializeField] public GameObject pauseMenuGroup;
    [SerializeField] private bool isPaused;

    void Start()
    {
        pauseMenuGroup.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKeyCode))
        {
            if (!isPaused) Pause();
            else Unpause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuGroup.SetActive(true);
        isPaused = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenuGroup.SetActive(false);
        isPaused = false;
    }
}
