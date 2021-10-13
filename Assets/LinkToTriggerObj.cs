using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LinkToTriggerObj : MonoBehaviour
{
    LineRenderer line;
    public List<GameObject> linkedObjs;
    public Color lineColor;
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        
    }
    void Start()
    {
        line.startColor = lineColor;
        line.endColor = lineColor;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, linkedObjs[0].transform.position);
        line.SetPosition(1, linkedObjs[1].transform.position);
    }
}
