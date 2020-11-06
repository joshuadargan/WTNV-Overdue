using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class LibrarianBehavior : MonoBehaviour
{
	
	public Animator Libanimator;
	public bool VoverH;
	
    // Start is called before the first frame update
    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    
    void Update(){
    
    	float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");	
        
        if (Math.Abs(inputX) > Math.Abs(inputY)){
        	VoverH = false;
        }else if (Math.Abs(inputY) > Math.Abs(inputX)){
        	VoverH = true;
        }
    	
       Libanimator.SetFloat("Horizontal", inputX);
       Libanimator.SetFloat("Vertical", inputY);
       Libanimator.SetBool("VoverH", VoverH);
       
       Debug.Log("Horiztonal = " + inputX);
       Debug.Log("Vertical = " + inputY);
       Debug.Log("VoverH = " + VoverH);
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
