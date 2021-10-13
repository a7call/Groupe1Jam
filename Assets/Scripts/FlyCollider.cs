using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCollider : MonoBehaviour
{
    [SerializeField] private GameObject Enfant;
    [SerializeField] private bool col, anim;
    [SerializeField] private bool CanDie;
    public bool enable;
    Animator m_animator;
    Collider collide;
    Animator animat;

    void Start ()
    {
        m_animator = GetComponent<Animator>();

        if (col)
        {
            collide = Enfant.GetComponent<Collider>();
            if (collide.enabled)
            {
                //material.EnableKeyword("_EMISSION");
                m_animator.SetBool("Enable", true);
            }
            else
            {
                //material.DisableKeyword("_EMISSION");
                m_animator.SetBool("Enable", false);
            }
        }

        if (anim)
        {
            animat = Enfant.GetComponent<Animator>();
            if (animat.enabled)
            {
                // material.EnableKeyword("_EMISSION");
                m_animator.SetBool("Enable", true);
            }
            else
            {
                // material.DisableKeyword("_EMISSION");
                m_animator.SetBool("Enable", false);
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
                //material.DisableKeyword("_EMISSION");
                m_animator.SetBool("Enable", false);

                if (CanDie)
                {
                    Destroy(gameObject);
                }
            }

            if (anim)
            {
                animat.enabled = false;
                enable = false;
                //material.DisableKeyword("_EMISSION");
                m_animator.SetBool("Enable", false);
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
                //material.EnableKeyword("_EMISSION");
                m_animator.SetBool("Enable", true);

                if (CanDie)
                {
                    Destroy(gameObject);
                }
            }

            if (anim)
            {
                animat.enabled = true;
                enable = true;
                // material.EnableKeyword("_EMISSION");
                m_animator.SetBool("Enable", true);
                print("Animation ON");


                if (CanDie)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
