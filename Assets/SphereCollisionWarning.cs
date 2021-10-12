using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SphereCollisionWarning : MonoBehaviour
{
    [SerializeField]
    private SphereCollider myCollider;
    public TextMeshProUGUI warningMessage;
    public string collidingTag;

    private void OnTriggerEnter(Collider other)
    {
        if (!myCollider.enabled && other.CompareTag(collidingTag))
        {
            warningMessage.text = "WARNING : enable the enemy's collider to shoot them";
        }
    }

}
