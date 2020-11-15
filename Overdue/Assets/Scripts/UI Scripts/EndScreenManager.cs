using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] public GameObject LOSE;
    [SerializeField] public GameObject WIN;

    bool win;

    public AudioSource doorSlam;
    public AudioSource doorOpen;
    public AudioSource shush;

    // Start is called before the first frame update
    void Start()
    {
        LOSE.SetActive(false);
        WIN.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Librarian" &&
            collision.gameObject.GetComponent<LibrarianBehavior>().IsSuspicious() &&
            !CheatCodeInput.debugMode && !CheatCodeInput.invincible &&
            !RepllentPickup.IsPlayerRepellant)
        {
            LOSE.SetActive(true);
            doorSlam.Play();
            shush.Play();
            Time.timeScale = 0f;
            Debug.Log("You lose");

            StartCoroutine(MoveGameForward(2));
        }

    }

    public void Win()
    {
        WIN.SetActive(true);
        Time.timeScale = 0f;

        Debug.Log("Win");
        doorOpen.Play();

        StartCoroutine(MoveGameForward(2));
    }

    public IEnumerator MoveGameForward(int SceneSwitchDelay) {          // DOES NOT WORK

        yield return new WaitForSeconds(SceneSwitchDelay);

        Debug.Log("Checkpoint1");

        if (win == false)
        {
            SceneManager.LoadScene(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
        else if (win == true)
        {
            SceneManager.LoadScene(0);
            Debug.Log("Checkpoint2");

        }



    }
}
