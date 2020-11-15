﻿using System.Collections;
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

	public AudioSource neutralHiss;
	public AudioSource walkSound;
  public AudioSource chaseSound;
	public AudioSource suspiciousHiss;
  bool playAudio;

    const float baseSpeed = 3.5f;
    private float suspicion = 0;

    private float playerDist;
    private float volume;

    private NavMeshAgent agent;

    private GameObject target;

    public void DecrementSuspicion()
    {
        suspicion -= Time.deltaTime;
    }

    public void SetSuspicion(int sus)
    {
        suspicion = sus;
        if(!suspiciousHiss.isPlaying && playAudio)
        {
          Debug.Log("player acting sus");
          suspiciousHiss.Play();
        }
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
        target = GameObject.Find(GameObjectNames.Player);
        playAudio = true;
    }

    void Update() {
        if (IsSuspicious() || target.GetComponent<RepllentPickup>().IsRepellant())
        {
            agent.speed = baseSpeed * 2;
            DecrementSuspicion();
            if (CheatCodeInput.debugMode)
                Debug.Log("Sus " + suspicion);
        }
        else
        {
            agent.speed = baseSpeed;
        }

    	Direction = transform.position - prevPos;
			if(agent.speed == baseSpeed && !walkSound.isPlaying && playAudio)
			{
				walkSound.Play();
			}
            else if(agent.speed == baseSpeed * 2 && !suspiciousHiss.isPlaying && playAudio)
            {
                suspiciousHiss.Play();
            }


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

    void OnCollisionEnter2D(Collision2D collision)
    {

      if(collision.gameObject.tag == "Player")
      {
        playAudio = false;
        neutralHiss.Stop();
        walkSound.Stop();
        chaseSound.Stop();
        suspiciousHiss.Stop();
      }
    }



    //// Update is called once per frame
    //void Update()
    //{

    //}
}
