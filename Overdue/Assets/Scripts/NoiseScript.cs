using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject NoiseTarget;
    private bool timerRunning = false;
    private bool systemOn = false;
    public float soundTimer = 5f;

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.isMakingNoise == true)
        {
            systemOn = true;

            if (gameObject.transform.position != Player.gameObject.transform.position)
            {
                gameObject.transform.position = Player.gameObject.transform.position;       //set this position to player position
            }


          if (NoiseTarget.activeInHierarchy == false) NoiseTarget.SetActive(true);

           if (timerRunning == true)
           {
                StopCoroutine(DeactivateSource());
                timerRunning = false;           //this functions should reset the timer countdown
           }

        }
        else if (PlayerMovement.isMakingNoise == false && timerRunning == false && systemOn == true) {

            StartCoroutine(DeactivateSource());
        }
    }

    void OnTriggerEnter2D(Collider2D col) //deactivates the game object after it collides with Librarian     //the collision with the Librarian is not being detected
    {
        Debug.Log("collided");

       if(col.gameObject.tag == "Lib_Sound_Detect")
        {
            Debug.Log("Librarian reached me");

            NoiseTarget.SetActive(false);
            StopCoroutine(DeactivateSource());
            timerRunning = false;
            systemOn = false;
        }
    }


    public IEnumerator DeactivateSource()           //deactivates game object automatically after time
    {
        timerRunning = true;

        yield return new WaitForSeconds(soundTimer);
       
        NoiseTarget.SetActive(false);
        timerRunning = false;
        systemOn = false;
    }   

}
