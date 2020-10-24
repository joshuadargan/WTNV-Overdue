using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnCart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ReturnCartManager.AddReturnCart(this.gameObject);
    }
}
