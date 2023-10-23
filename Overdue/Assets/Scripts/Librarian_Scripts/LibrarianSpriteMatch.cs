using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibrarianSpriteMatch : MonoBehaviour
{
    public SpriteRenderer baseLayer;
    SpriteRenderer maskLayer;
    void Start()
    {
        maskLayer = gameObject.GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (maskLayer.sprite != baseLayer.sprite) {

            maskLayer.sprite = baseLayer.sprite;    
        }
    }
}
