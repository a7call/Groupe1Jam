using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCount : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemy = new List<GameObject>();
    [SerializeField] private GameObject Exit;

    private void Update()
    {
        foreach (var EN in enemy.ToArray())
        {
            if (!EN.activeSelf)
            {
                enemy.Remove(EN);
            }
        }
        if (enemy.Count == 0)
        {
            Exit.SetActive(true);
        }
    }
}
