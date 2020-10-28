using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        //animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        
        //Debug.Log("Angle = " + angle);
        
        animator.SetFloat("angle", angle);
 
        
       /* if (angle > -45 && angle < 45){
        	
        }else if(angle > 45 && angle < 135){
        
        }else if(angle > 135 || angle < -135){
        
        }else if(angle > -135 && angle < -45){
        
        }*/
    }
}
