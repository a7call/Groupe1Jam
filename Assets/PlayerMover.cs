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

    [field: SerializeField]
    public float JumpForce { get; private set; }

    public bool IsGrounded { get; set; }

    [field: SerializeField]
    private Transform FeetPos { get; set; }

    [field: SerializeField]
    private float CheckRadius { get; set; }

    public LayerMask GroundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
               ApplyGravity();
    }
    private void Update()
    {
        CheckIfGrounded();
    }
    public void ApplyGravity()
    {
        rb.velocity += Physics.gravity * 20 * Time.fixedDeltaTime;
    }
    void CheckIfGrounded()
    {
        if (Physics.OverlapSphere(FeetPos.position, CheckRadius, GroundLayer).Length > 0)
            IsGrounded = true;
        else
        {
            IsGrounded = false;
        }
    }

    public void Move(Vector2 dir)
    {
        rb.AddForce(mouvementForce * dir, ForceMode.Impulse);
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(FeetPos.position, CheckRadius);
    }

}
