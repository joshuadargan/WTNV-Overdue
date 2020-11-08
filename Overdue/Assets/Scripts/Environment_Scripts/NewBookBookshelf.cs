using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBookBookshelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NewBookBookshelfManager.AddBookshelf(this.gameObject);
    }
}
