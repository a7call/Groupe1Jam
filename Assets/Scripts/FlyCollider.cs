using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCollider : MonoBehaviour
{
    [SerializeField] private GameObject Enfant;
    [SerializeField] private bool col, anim;
    [SerializeField] private bool CanDie;
    public bool enable;
    Material material;
    Collider collide;
    Animator animat;

    void Start ()
    {
        material = GetComponent<Renderer>().material;

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
                material.color = Color.red;

                if (CanDie)
                {
                    Destroy(gameObject);
                }
            }

            if (anim)
            {
                animat.enabled = false;
                enable = false;
                material.color = Color.red;

                if (CanDie)
                {
                    Destroy(gameObject);
                }
            }
        }

        else if (other.CompareTag ("BulletPlayer") && !enable)
        {
            if (col)
            {
                collide.enabled = true;
                enable = true;
                print("Collider ON");
                material.color = Color.blue;

                if (CanDie)
                {
                    Destroy(gameObject);
                }
            }

            if (anim)
            {
                animat.enabled = true;
                enable = true;
                material.color = Color.blue;

                if (CanDie)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
