using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

public class PlayerInputHandle : MonoBehaviour
{
    PlayerInput input;
    // Player scripts
    PlayerMover mover;
    PlayerShootManager shootManager;
    
    // Input variable
    Vector2 Mouvement { get; set; }
    Vector3 AimDirection { get; set; }

    //Jump
    public bool isAbleToJump = true;
    public float holdTime = 1f;
    private float holdTimer;
    float jumpSate = 0;
    public float coyoteTimeCounter;
    public float coyoteTime;


    private Animator animator;

   


    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        var index = input.playerIndex;

        animator = GetComponent<Animator>();
        shootManager = GetComponent<PlayerShootManager>();

        var shootManagers = FindObjectsOfType<PlayerShootManager>();
        var movers = FindObjectsOfType<PlayerMover>();

        shootManager = shootManagers.FirstOrDefault(m => m.playerIndex == index);
        mover = movers.FirstOrDefault(m => m.playerIndex == index);
    }
    private void FixedUpdate()
    {
        Mouvement = new Vector2(Mouvement.x, 0);
        mover.Move(Mouvement * Time.fixedDeltaTime);

        holdTimer -= Time.fixedDeltaTime;

        if (jumpSate == 1 && holdTimer > 0)
        {   
            mover.Jump();
        }
      
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
        }
        else
        {
            jumpSate = 0;
        }

        if (jumpSate == 1)
            holdTimer = holdTime;
    }

    private float GetJumpControlVal(float value)
    {
        return value;
    }
    void JumpCo()
    {
       
             
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
