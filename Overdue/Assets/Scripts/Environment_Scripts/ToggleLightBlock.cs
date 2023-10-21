using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLightBlock : MonoBehaviour
{
    public GameObject Shadow;
    private bool isCrouching;

    void Update()
    {
        if (Input.GetButton("Crouch"))
        {
            Shadow.SetActive(true);
           // gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.layer = 0;                                            //set layer to block raycasts

            isCrouching = true;
        }
        else if (isCrouching == true) {

            Shadow.SetActive(false);
           // gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            gameObject.layer = 2;                                           //set layer it ignore raycasts

            isCrouching = false;
        }
    }
}
