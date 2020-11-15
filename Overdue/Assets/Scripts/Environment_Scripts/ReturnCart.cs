using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnCart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("ObjectiveManager").GetComponent<ReturnCartManager>().AddReturnCart(this.gameObject);
    }
}
