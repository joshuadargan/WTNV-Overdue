using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenManager2 : MonoBehaviour
{
    [SerializeField] public GameObject LOSE;
    [SerializeField] public GameObject WIN;

    bool win;

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
            !CheatCodeInput.debugMode && !CheatCodeInput.invincible)
        {
            LOSE.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("You lose");
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            WIN.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
