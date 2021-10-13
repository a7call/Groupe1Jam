using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private List< GameObject>  enemy = new List<GameObject> ();

    private void Update()
    {
        foreach (var EN in enemy.ToArray())
        {
            if (EN == null)
            {
                enemy.Remove(EN);
            }
        }
        if (enemy.Count <= 0)
            {
            Destroy(gameObject);
            }
    }
}
