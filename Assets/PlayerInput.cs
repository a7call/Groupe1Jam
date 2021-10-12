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
    Vector3 AimDirection { get; set; }


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
        Mouvement = new Vector2(Mouvement.x, 0);
        mover.Move(Mouvement * Time.fixedDeltaTime);
    }
    public void OnJump(InputValue value)
    {

        if (mover.IsGrounded())
        {
            mover.Jump();
        }
    }
    public void OnFire()
    {
        if (AimDirection == Vector3.zero)
            AimDirection = Vector3.right;

        shootManager.Fire(AimDirection.normalized);
    }


    public void OnAim(InputValue value)
    {
        AimDirection = value.Get<Vector2>();
    }



}
