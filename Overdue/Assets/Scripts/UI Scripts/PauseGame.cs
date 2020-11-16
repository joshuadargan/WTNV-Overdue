using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public KeyCode pauseKeyCode;
    [SerializeField] public GameObject pauseMenuGroup;
    [SerializeField] public GameObject collectibleMenuGroup;
    [SerializeField] public GameObject mapMenuGroup;
    [SerializeField] public bool isPaused { get; private set; }

    void Start(){
       
        pauseMenuGroup.SetActive(false);
        collectibleMenuGroup.SetActive(false);
        mapMenuGroup.SetActive(false);
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
        if (mapMenuGroup)
            mapMenuGroup.SetActive(false);
        isPaused = false;
    }

    public void Read()
    {
        Time.timeScale = 0f;
        collectibleMenuGroup.SetActive(true);
        isPaused = true;
    }

    public void OpenMap(SpriteRenderer map)
    {
        Time.timeScale = 0f;
        mapMenuGroup.SetActive(true);
        mapMenuGroup.GetComponentInChildren<Image>().sprite = map.sprite;
        isPaused = true;
    }
}
