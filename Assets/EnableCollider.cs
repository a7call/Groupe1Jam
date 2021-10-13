using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCollider : MonoBehaviour
{
    Collider Collide;

    private void Start()
    {
        Collide = GetComponent<Collider>();
        StartCoroutine("Collid");
    }

    IEnumerator Collid ()
    {
        yield return new WaitForSeconds(3);
        Collide.enabled = true;
        yield return null;
    }
}
