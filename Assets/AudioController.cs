using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : Singleton<AudioController>
{
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    private void Update()
    {
         if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            Destroy(gameObject);
        }
    }
}
