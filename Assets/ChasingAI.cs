using System.Collections;
using UnityEngine;


public class ChasingAI : AI
{    
    protected override void Start()
    {
        base.Start();
        target = GetClosestPlayer().transform;
        InvokeRepeating("UpdatePath", 0, rePathRate);       
    }
    protected override void UpdatePath()
    {
        if(gameObject.activeSelf)
            agent.destination = target.position;
    }

}
