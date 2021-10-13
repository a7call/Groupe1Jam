using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private int NumScene;
    [SerializeField] private GameObject Player1, Player2;
    private bool Play1, Play2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player1)
        {
            Play1 = true;
            print("Play1 on");
        }

        if (other.gameObject == Player2)
        {
            Play2 = true;
            print("Play2 on");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player1)
        {
            Play1 = false;
            print("Play1 off");
        }

        if (other.gameObject == Player2)
        {
            Play2 = false;
            print("Play2 off");
        }
    }

    private void Update()
    {
        if (Play1 && Play2)
        {
            SceneManager.LoadScene(NumScene);
        }
    }
}
