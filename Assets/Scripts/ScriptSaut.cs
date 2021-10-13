using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSaut : MonoBehaviour
{
    [SerializeField] private GameObject Player;
 

    private void OnDestroy()
    {
     
        Player.GetComponent<PlayerInput>().isAbleToJump = true;
        print("Jump Unlock");

    }
}
