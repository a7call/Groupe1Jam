using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LinkToTriggerObj : MonoBehaviour
{
    LineRenderer line;
    public List<GameObject> linkedObjs;
    public bool isEnable = true;
    public Color lineColorActive;
    public Color lineColorDesactive;
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        
    }
    void Start()
    {
        if (isEnable)
        {
            line.startColor = lineColorActive;
            line.endColor = lineColorActive;
        }
        else
        {
            line.startColor = lineColorDesactive;
            line.endColor = lineColorDesactive;
        }
      
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, linkedObjs[0].transform.position);
        line.SetPosition(1, linkedObjs[1].transform.position);
    }

    public void ToggleRenderer()
    {
        if (isEnable)
        {
            isEnable = !isEnable;
            line.startColor = lineColorDesactive;
            line.endColor = lineColorDesactive;
        }
        else
        {

            isEnable = !isEnable;
            line.startColor = lineColorActive;
            line.endColor = lineColorActive;
        }
    }
}
