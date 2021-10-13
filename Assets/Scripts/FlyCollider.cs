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
            if (collide.enabled)
            {
                material.EnableKeyword("_EMISSION");
            }
            else
            {
                material.DisableKeyword("_EMISSION");
            }
        }

        if (anim)
        {
            animat = Enfant.GetComponent<Animator>();
            if (animat.enabled)
            {
                material.EnableKeyword("_EMISSION");
            }
            else
            {
                material.DisableKeyword("_EMISSION");
            }
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
                material.DisableKeyword("_EMISSION");
                
                if (CanDie)
                {
                    Destroy(gameObject);
                }
            }

            if (anim)
            {
                animat.enabled = false;
                enable = false;
                material.DisableKeyword("_EMISSION");
                print("Animation OFF");

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
                material.EnableKeyword("_EMISSION");

                if (CanDie)
                {
                    Destroy(gameObject);
                }
            }

            if (anim)
            {
                animat.enabled = true;
                enable = true;
                material.EnableKeyword("_EMISSION");
                print("Animation ON");


                if (CanDie)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
