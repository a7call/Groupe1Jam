using System.Collections;
using UnityEngine;


public class ChasingAI : AI
{    
    protected override void Start()
    {
        base.Start();
        InvokeRepeating("UpdatePath", 0, rePathRate);       
    }
    protected override void UpdatePath()
    {
        if(gameObject.activeSelf && target != null)
            agent.destination = target.position;
    }

}
