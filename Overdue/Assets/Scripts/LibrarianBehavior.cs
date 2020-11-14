using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class LibrarianBehavior : MonoBehaviour
{
	
	public Animator animator;
	bool VoverH;
	
	private Vector3 prevPos;
	private Vector3 Direction;
	float Horizontal;
	float Vertical;

    const float baseSpeed = 3.5f;
    private float suspicion = 0;

    private NavMeshAgent agent;

    public void DecrementSuspicion()
    {
        suspicion -= Time.deltaTime;
    }

    public void SetSuspicion(int sus)
    {
        suspicion = sus;
    }

    public bool IsSuspicious()
    {
        return suspicion > 0;
    }
	
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        prevPos = transform.position;
    }

    void Update() {
        if (IsSuspicious() || RepllentPickup.IsPlayerRepellant)
        {
            agent.speed = baseSpeed * 2;
            DecrementSuspicion();
        }
        else
        {
            agent.speed = baseSpeed;
        }

    	Direction = transform.position - prevPos;
    	
    	
    	Horizontal = Direction.x;
    	Vertical = Direction.y;
    	
    	if (Math.Abs(Horizontal) > Math.Abs(Vertical)){
        	VoverH = false;
        } else if (Math.Abs(Vertical) > Math.Abs(Horizontal)){
        	VoverH = true;
        }
    	
       animator.SetFloat("Horizontal", Horizontal);
       animator.SetFloat("Vertical", Vertical);
       animator.SetBool("VoverH", VoverH);
       
       prevPos = transform.position;
       
       
    }

    

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
