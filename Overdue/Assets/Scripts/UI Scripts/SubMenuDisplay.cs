using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenuDisplay : MonoBehaviour
{

    [SerializeField] public GameObject subMenuGroup;
    //[SerializeField] private bool isDisplayed;

    // Start is called before the first frame update
    void Start()
    {
        subMenuGroup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show() {
        subMenuGroup.SetActive(true);
       // isDisplayed = true;
    }

    public void Unshow() {
        subMenuGroup.SetActive(false);
       // isDisplayed = false;
    }
}

