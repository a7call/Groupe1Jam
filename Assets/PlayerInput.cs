using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // Player scripts
    PlayerMover mover;
    PlayerShootManager shootManager;
    
    // Input variable
    Vector2 Mouvement { get; set; }
    Vector3 AimDirection { get; set; }

    //Jump
    public bool isAbleToJump = true;
    public float holdTimer = 1f;
    float jumpSate = 0;
    private float coyoteTimeCounter;
    public float coyoteTime;


    private Animator animator;

   


    private void Awake()
    {
        animator = GetComponent<Animator>();
        shootManager = GetComponent<PlayerShootManager>();
        mover = GetComponent<PlayerMover>();
    }
    private void FixedUpdate()
    {
        Mouvement = new Vector2(Mouvement.x, 0);
        mover.Move(Mouvement * Time.fixedDeltaTime);
    }

    private void Update()
    {
        if (mover.IsGrounded())
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;
    }

    void OnMove(InputValue value)
    {
        Mouvement = value.Get<Vector2>();
    }
   
    #region Jump
    public void OnJump(InputValue value)
    {
        jumpSate = GetJumpControlVal(value.Get<float>());

        if (coyoteTimeCounter > 0 && isAbleToJump)
        {
            coyoteTimeCounter = 0;

            if(jumpSate == 1)
                animator.SetTrigger("isJumping");

            StartCoroutine(JumpCo());
        }
    }

    private float GetJumpControlVal(float value)
    {
        return value;
    }
    IEnumerator JumpCo()
    {
        var hold = holdTimer;
        while(jumpSate == 1 && hold > 0)
        {
            hold -= Time.fixedDeltaTime;
            mover.Jump();
            yield return null;
        }          
    }
    #endregion

    #region Shoot
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
    #endregion



}
