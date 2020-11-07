using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           // displayed.SetActive(false);
            //Destroy(gameObject);
           // RepellentIcon.SetActive(true);
           // RepellentStored++;
        }
    }
}
