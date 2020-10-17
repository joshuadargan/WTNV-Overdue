using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health_Segmented : MonoBehaviour {
    // InstaDeath objects should be tagged "Death" and set as a trigger
    // Enemies (and other 1-damage obstacles) should be tagged "Enemy" and should NOT be set as a trigger

    private GameObject respawn;

    private int playerScore;
   

    [Tooltip("The score value of a coin or pickup.")]
    public int coinValue = 1;
    [Tooltip("The amount of points a player loses on death.")]
    public int deathPenalty = 0;

    public Text scoreText;
    // Feel free to add more! You'll need to edit the script in a few spots, though.
    public GameObject health19;
    public GameObject health18;
    public GameObject health17;
    public GameObject health16;
    public GameObject health15;
    public GameObject health14;
    public GameObject health13;
    public GameObject health12;
    public GameObject health11;
    public GameObject health10;
    public GameObject health9;
    public GameObject health8;
    public GameObject health7;
    public GameObject health6;
    public GameObject health5;
    public GameObject health4;
    public GameObject health3;
    public GameObject health2;
    public GameObject health1;



    // Use this for initialization
    void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        playerScore = 0;
        scoreText.text = playerScore.ToString("D1");

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            Respawn();
        }
        else if (collision.CompareTag("Coin"))
        {
            AddPoints(coinValue);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Finish"))
        {
            Time.timeScale = 0;
        }
        else if (collision.CompareTag("Health"))
        {
            AddHealth();
            Destroy(collision.gameObject);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        // For more health, copy the if block for health3, change health3 to whatever yours is,
        // then change the if statement for health3 to else if

        if (health19.activeInHierarchy)
        {
            health19.SetActive(false);
        }
        else if (health18.activeInHierarchy)
        {
            health18.SetActive(false);
        }
        else if (health17.activeInHierarchy)
        {
            health17.SetActive(false);
        }
        else if (health16.activeInHierarchy)
        {
            health16.SetActive(false);
        }
        else if (health15.activeInHierarchy)
        {
            health15.SetActive(false);
        }
        else if (health14.activeInHierarchy)
        {
            health14.SetActive(false);
        }
        else if (health13.activeInHierarchy)
        {
            health13.SetActive(false);
        }
        else if (health12.activeInHierarchy)
        {
            health12.SetActive(false);
        }
        else if (health11.activeInHierarchy)
        {
            health11.SetActive(false);
        }
        else if (health10.activeInHierarchy)
        {
            health10.SetActive(false);
        }
        else if (health9.activeInHierarchy)
        {
            health9.SetActive(false);
        }
        else if (health8.activeInHierarchy)
        {
            health8.SetActive(false);
        }
        else if (health7.activeInHierarchy)
        {
            health7.SetActive(false);
        }
        else if (health6.activeInHierarchy)
        {
            health6.SetActive(false);
        }
        else if (health5.activeInHierarchy)
        {
            health5.SetActive(false);
        }
        else if (health4.activeInHierarchy)
        {
            health4.SetActive(false);
        }
        else if (health3.activeInHierarchy)
        {
            health3.SetActive(false);
        }
        else if (health2.activeInHierarchy)
        {
            health2.SetActive(false);
        }
        else
        {
            health1.SetActive(false);
            Respawn();
        }
    }

    private void AddHealth()
    {
        if (!health2.activeInHierarchy)
        {
            health2.SetActive(true);
        }
        else if (!health3.activeInHierarchy)
        {
            health3.SetActive(true);
        }
        else if (!health4.activeInHierarchy)
        {
            health4.SetActive(true);
        }
        else if (!health5.activeInHierarchy)
        {
            health5.SetActive(true);
        }
        else if (!health6.activeInHierarchy)
        {
            health6.SetActive(true);
        }
        else if (!health7.activeInHierarchy)
        {
            health7.SetActive(true);
        }
        else if (!health8.activeInHierarchy)
        {
            health8.SetActive(true);
        }
        else if (!health9.activeInHierarchy)
        {
            health9.SetActive(true);
        }
        else if (!health10.activeInHierarchy)
        {
            health10.SetActive(true);
        }
        else if (!health11.activeInHierarchy)
        {
            health11.SetActive(true);
        }
        else if (!health12.activeInHierarchy)
        {
            health12.SetActive(true);
        }
        else if (!health13.activeInHierarchy)
        {
            health13.SetActive(true);
        }
        else if (!health14.activeInHierarchy)
        {
            health14.SetActive(true);
        }
        else if (!health15.activeInHierarchy)
        {
            health15.SetActive(true);
        }
        else if (!health16.activeInHierarchy)
        {
            health16.SetActive(true);
        }
        else if (!health17.activeInHierarchy)
        {
            health17.SetActive(true);
        }
        else if (!health18.activeInHierarchy)
        {
            health18.SetActive(true);
        }
        else if(!health19.activeInHierarchy)
        {
            health19.SetActive(true);
        }
        // For more health, just copy the else if block for health3 and change the name.
    }

    public void Respawn()
    {
        // For more health, just add another similar line here.
        health19.SetActive(true);
        health18.SetActive(true);
        health17.SetActive(true);
        health16.SetActive(true);
        health15.SetActive(true);
        health14.SetActive(true);
        health13.SetActive(true);
        health12.SetActive(true);
        health11.SetActive(true);
        health10.SetActive(true);
        health9.SetActive(true);
        health8.SetActive(true);
        health7.SetActive(true);
        health6.SetActive(true);
        health5.SetActive(true);
        health4.SetActive(true);
        health3.SetActive(true);
        health2.SetActive(true);
        health1.SetActive(true);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.transform.position = respawn.transform.position;
        AddPoints(deathPenalty);
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void AddPoints(int amount)
    {
        playerScore += amount;
        scoreText.text = playerScore.ToString("D1");
    }
}
