using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCollider : MonoBehaviour
{
    [SerializeField] private GameObject Enfant;
    [SerializeField] private bool col, anim;
    [SerializeField] private bool CanDie;
    [SerializeField] private Material orange, blue;
    public bool enable;
    MeshRenderer meshRenderer;
    Collider collide;
    Animator animat;

    void Start ()
    {
        meshRenderer = GetComponent<MeshRenderer>();

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
                meshRenderer.material = orange;
                
                if (CanDie)
                {
                    Destroy(gameObject);
                }
            }

            if (anim)
            {
                animat.enabled = false;
                enable = false;
                meshRenderer.material = orange;

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
                meshRenderer.material = blue;

                if (CanDie)
                {
                    Destroy(gameObject);
                }
            }

            if (anim)
            {
                animat.enabled = true;
                enable = true;
                meshRenderer.material = blue;

                if (CanDie)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
