using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody rb;
    [SerializeField]
    private float mouvementForce;

    public int playerIndex;

    [field: SerializeField]
    public float JumpForce { get; private set; }

    [field: SerializeField]
    private Transform FeetPos { get; set; }

    [field: SerializeField]
    private float CheckRadius { get; set; }

    public LayerMask GroundLayer;

    public float maxJumpForce;

    public float fallForce;
    private bool isJumping;
    private Animator animator;

    private void Awake()
    { 
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    
    int GetPlayerIndex()
    {
        return playerIndex;
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y < 0f)
        {
            ApplyGravity();
            isJumping = false;
        }           
    }
    public void ApplyGravity()
    {
        rb.velocity += Physics.gravity * fallForce * Time.fixedDeltaTime;
    }
    public bool IsGrounded()
    {
        if (Physics.OverlapSphere(FeetPos.position, CheckRadius, GroundLayer).Length > 0)
        {
            
            return  true;
        }      
        else
        {

            return false;
        }
    }
    public void Move(Vector2 dir)
    {
        rb.AddForce(mouvementForce * dir, ForceMode.Impulse);
    }

    public void Jump()
    {
        if (!isJumping)
        {
            animator.SetTrigger("isJumping");
            isJumping = true;
        }
          
        rb.velocity += Vector3.up * JumpForce; 
        var ClampYVel = rb.velocity;
        ClampYVel.y = Mathf.Clamp(ClampYVel.y, 0, maxJumpForce);
        rb.velocity = new Vector3(rb.velocity.x, ClampYVel.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(FeetPos.position, CheckRadius);
    }

}
