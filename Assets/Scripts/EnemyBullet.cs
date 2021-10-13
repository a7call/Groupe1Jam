using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBullet : MonoBehaviour
{
    private Transform Player;
    [SerializeField] private float speed;
    private Vector3 PlayerPos;
    private Rigidbody rb;
    public GameObject origin;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = origin.GetComponent<AI>().target;
        //PlayerPos = Player.transform.position;
        transform.LookAt(Player.transform.position);
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, PlayerPos, speed * Time.deltaTime) ;
        rb.velocity = transform.forward * speed;
    }
    private void OnCollisionEnter(Collision other)
    {        
       Destroy(gameObject);            
    }


}