using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationTrigger : MonoBehaviour {

    [SerializeField] private GameObject displayed;
    int RepellentStored = 0;
    public GameObject RepellentIcon;

    void Start()
    {
        displayed.SetActive(true);
        RepellentIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            displayed.SetActive(false);
            RepellentIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            displayed.SetActive(true);
        }
    }
}
