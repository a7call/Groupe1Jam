using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WanderingAI : AI
{

    protected override void Start()
    {
        base.Start();
        agent.destination = GetPointToGo();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPathDone())
            UpdatePath();

        if (agent.velocity == Vector3.zero && !isForcingRepath)
        {
            isForcingRepath = true;
            StartCoroutine(ForceRepath());
        }
    }

    protected override void UpdatePath()
    {
        if (gameObject.activeSelf)
        {
            agent.destination = GetPointToGo();
            Destination = agent.destination;
        }
    }


    public override void StartDeathCycle()
    {
       // Nothing To do;
    }

}
