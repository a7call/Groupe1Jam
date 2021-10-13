using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCollider : MonoBehaviour
{
    public GameObject rayObject;
    [SerializeField] private GameObject Enfant;
    [SerializeField] private bool col, anim;
    [SerializeField] private bool CanDie;
    public bool enable;
    Animator m_animator;
    Collider collide;
    Animator animat;
    MeshRenderer m_childMeshRenderer;
    Material m_childMaterial;

    void Start ()
    {
        m_animator = GetComponent<Animator>();
        m_childMeshRenderer = Enfant.GetComponent<MeshRenderer>();
        m_childMaterial = m_childMeshRenderer.material;

        if (col)
        {
            collide = Enfant.GetComponent<Collider>();
            if (collide.enabled)
            {
                m_childMaterial.EnableKeyword("_EMISSION");
                m_animator.SetBool("Enable", true);
            }
            else
            {
                m_childMaterial.DisableKeyword("_EMISSION");
                m_animator.SetBool("Enable", false);
            }
        }

        if (anim)
        {
            animat = Enfant.GetComponent<Animator>();
            if (animat.enabled)
            {
                m_childMaterial.EnableKeyword("_EMISSION");
                m_animator.SetBool("Enable", true);
            }
            else
            {
                m_childMaterial.DisableKeyword("_EMISSION");
                m_animator.SetBool("Enable", false);
            }
        }        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("BulletPlayer") && enable)
        {
            if (rayObject != null)
                rayObject.GetComponent<LinkToTriggerObj>().ToggleRenderer();
            if (col)
            {
                collide.enabled = false;
                enable = false;
                print("Collider OFF");
                m_childMaterial.DisableKeyword("_EMISSION");
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
                m_childMaterial.DisableKeyword("_EMISSION");
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
            if(rayObject!= null)
                rayObject.GetComponent<LinkToTriggerObj>().ToggleRenderer();
            if (col)
            {
                collide.enabled = true;
                enable = true;
                print("Collider ON");
                m_childMaterial.EnableKeyword("_EMISSION");
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
                m_childMaterial.EnableKeyword("_EMISSION");
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
