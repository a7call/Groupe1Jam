using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private int NumScene;
    [SerializeField] private GameObject Player1, Player2;
    private void OnTriggerEnter(Collider other)
    {
        if (Player1 && Player2)
        {
            SceneManager.LoadScene(NumScene);
        }
    }
}
