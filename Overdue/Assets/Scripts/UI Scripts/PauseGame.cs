using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public KeyCode pauseKeyCode;
    [SerializeField] public GameObject pauseMenuGroup;
    [SerializeField] public GameObject collectibleMenuGroup;
    [SerializeField] public bool isPaused { get; private set; }

    void Start(){
       
        pauseMenuGroup.SetActive(false);
        collectibleMenuGroup.SetActive(false);
    }

    void Update(){
        
        if (Input.GetKeyDown(pauseKeyCode)){
            if (!isPaused) Pause();
            else Unpause();
        }
    }

    public void Pause(){
        Time.timeScale = 0f;
        pauseMenuGroup.SetActive(true);
        isPaused = true;
    }

    public void Unpause(){
        Time.timeScale = 1f;
        if (pauseMenuGroup)
            pauseMenuGroup.SetActive(false);
        if (collectibleMenuGroup)
            collectibleMenuGroup.SetActive(false);
        isPaused = false;
    }

    public void Read()
    {
        Time.timeScale = 0f;
        collectibleMenuGroup.SetActive(true);
        isPaused = true;
    }
}
