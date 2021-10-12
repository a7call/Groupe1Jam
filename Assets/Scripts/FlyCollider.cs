using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCollider : MonoBehaviour
{
    [SerializeField] private GameObject Enfant;
    private bool enable;

    BoxCollider boxcollider; 

    void Start ()
    {
        boxcollider = Enfant.GetComponent<BoxCollider>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("BulletPlayer") && enable)
        {
        boxcollider.enabled = false;
        enable = false;
        }

        else if (other.CompareTag ("BulletPlayer") && !enable)
        {
        boxcollider.enabled = true;
        enable = true;
        }
    }
}
