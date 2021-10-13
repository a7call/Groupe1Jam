using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullets : MonoBehaviour
{
    public Vector2 direction { get; set; }
    private Rigidbody rb;
    public float moveForce;
    public GameObject DirtPS;
    public PlayerShootManager origin;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.AddForce(moveForce * direction, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            //if (origin.playerIndex == collision.transform.GetComponent<AI>().index)
            //{
                var AI = collision.transform.GetComponent<AI>();
                if (AI != null)
                    AI.StartDeathCycle();
           // }
        }
        else if(DirtPS != null)
        {
            Instantiate(DirtPS, transform.position, Quaternion.identity);
        }
        gameObject.SetActive(false);

        Destroy(gameObject,2f);
    }

}