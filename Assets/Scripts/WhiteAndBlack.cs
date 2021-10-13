using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteAndBlack : MonoBehaviour
{
    [SerializeField] private bool Black;

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("BlackBullet") && Black)
        {
            Destroy(gameObject);
        }

        if (other.CompareTag ("WhiteBullet") && ! Black)
        {
            Destroy(gameObject);
        }
    }
}
