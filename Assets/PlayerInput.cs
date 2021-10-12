using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerMover mover;
    PlayerShootManager shootManager;
    float lookAngle;
    Vector2 Mouvement { get; set; }
   

    private void Awake()
    {
        shootManager = GetComponent<PlayerShootManager>();
        mover = GetComponent<PlayerMover>();
    }
    void OnMove(InputValue value)
    {

        Mouvement = value.Get<Vector2>();
    }
    private void FixedUpdate()
    {
        mover.Move(Mouvement * Time.fixedDeltaTime);
    }
    public void OnJump()
    {
        if (mover.IsGrounded())
        {
            mover.Jump();
        }      
    }
    public void OnFire()
    {
        var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        position = Camera.main.ScreenToWorldPoint(position);
        var dir = (position - transform.position).normalized;
        shootManager.Fire(dir.normalized);
    }

   

}
