using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject NoiseTarget;
    private bool timerRunning = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.isMakingNoise == true)
        {

            if (gameObject.transform.position != Player.gameObject.transform.position)
            {
                gameObject.transform.position = Player.gameObject.transform.position;       //Am I able to set the values for the position Vector3?
            }


            if (NoiseTarget.activeInHierarchy == false) NoiseTarget.SetActive(true);

            if (timerRunning == true)
            {
                StopCoroutine(DeactivateSource());
                timerRunning = false;           //this functions should reset the timer countdown
            }

        }
        else if (PlayerMovement.isMakingNoise == false) {

            StartCoroutine(DeactivateSource());
        }
    }

    private void OnTriggerEnter2D(Collider2D col)   //deactivates the game object after it collides with Librarian
    {    
        if(col.gameObject.tag == "Librarian"){

            NoiseTarget.SetActive(false);
            StopCoroutine(DeactivateSource());
            timerRunning = false;
        }
    }

    public IEnumerator DeactivateSource()           //deactivates game object automatically after a half second
    {
        timerRunning = true;

        yield return new WaitForSeconds(60);
        NoiseTarget.SetActive(false);

        timerRunning = false;
    }

}
