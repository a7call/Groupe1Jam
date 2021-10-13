using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private int NumScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            SceneManager.LoadScene(NumScene);
        }
    }
}
