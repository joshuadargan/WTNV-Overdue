using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchVisibility : MonoBehaviour
{

    public SpriteRenderer[] sprites;
    private bool spritesHidden;

    // Update is called once per frame
    void Update()
    {

        if (PlayerMovement.IsUnderTable == true && spritesHidden == false)
        {
            foreach (SpriteRenderer v in sprites) {

                v.enabled = false;
            }

            spritesHidden = true;
        }
        else if (PlayerMovement.IsUnderTable == false && spritesHidden == true) {

            foreach (SpriteRenderer v in sprites){

                v.enabled = true;
            }

            spritesHidden = false;
        }
    }
}
