using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : ClicAgentController
{
    private float speed = 2.5f;
    private NavMeshAgent movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (Input.GetButton("Jump"))
        {
            speed = 5f;
            GetComponent<NoiseStatus>().NoiseLevel = 1;
        }

        else
        {
            speed = 2.5f;
            GetComponent<NoiseStatus>().NoiseLevel = 0;
        }

        movement.speed = speed;
    }
}