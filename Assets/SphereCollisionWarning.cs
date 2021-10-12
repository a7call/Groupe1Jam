using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SphereCollisionWarning : MonoBehaviour
{
    [SerializeField]
    private SphereCollider myCollider;
    public TextMeshProUGUI warningMessage;

    private void OnTriggerEnter(Collider other)
    {
        if (myCollider.enabled == false)
        {
            //Debug.Log("WARNING : enable the enemy's collider to shoot them");
            warningMessage.text = "WARNING : enable the enemy's collider to shoot them";
        }
    }

}
