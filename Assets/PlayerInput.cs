using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerMover mover;
    Vector2 Mouvement { get; set; }
   

    private void Awake()
    {
        mover = GetComponent<PlayerMover>();
    }
    void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
        Mouvement = value.Get<Vector2>();
    }
    private void FixedUpdate()
    {
        mover.Move(Mouvement * Time.fixedDeltaTime);
    }

    public void OnJump()
    {
        if (mover.IsGrounded)
        {
            mover.Jump();

        }      
    }

   

}
