using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepllentPickup : MonoBehaviour {

    //[SerializeField] private GameObject displayed;
    public int RepellentStored = 0;
    public GameObject RepellentIcon;
    public const float repellantTime = 5;
    public float remainingRepellantTime = 0;

    void Start()
    {
        //displayed.SetActive(true);
        RepellentIcon.SetActive(false);
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.Q) && RepellentStored > 0 ) || CheatCodeInput.repel)
        {
            remainingRepellantTime = 5;
            RepellentStored--;
        }
        if (remainingRepellantTime > 0)
        {
            remainingRepellantTime -= Time.deltaTime;
        }
    }

    public bool IsRepellant()
    {
        return remainingRepellantTime > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("repellent_pickup"))
        {
            //displayed.SetActive(false);
            RepellentIcon.SetActive(true);
            RepellentStored++;
            Destroy(collision.gameObject);
        }
    }

   /* private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            displayed.SetActive(true);
        }
    }*/
}
