using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    PlayerInputManager manager;
    public Transform spawnPos1;
    public Transform spawnPos2;

    private void Start()
    {
    }

    private void OnPlayerJoined()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = spawnPos1.position;
    }
}
