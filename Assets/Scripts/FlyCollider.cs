using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCollider : MonoBehaviour
{
    [SerializeField] private GameObject Enfant;
    [SerializeField] private bool col, anim;
    public bool enable;

    Collider collide;
    Animator animat;

    void Start ()
    {
        if (col)
        {
            collide = Enfant.GetComponent<Collider>();
        }

        if (anim)
        {
            animat = Enfant.GetComponent<Animator>();
        }        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("BulletPlayer") && enable)
        {
            if (col)
            {
                collide.enabled = false;
                enable = false;
                print("Collider OFF");
            }

            if (anim)
            {
                animat.enabled = false;
                enable = false;
            }
        }

        else if (other.CompareTag ("BulletPlayer") && !enable)
        {
            if (col)
            {
                collide.enabled = true;
                enable = true;
                print("Collider ON");
            }

            if (anim)
            {
                animat.enabled = true;
                enable = true;
            }
        }
    }
}
