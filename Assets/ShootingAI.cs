using System;
using System.Collections;
using UnityEngine;


public class ShootingAI : AI
{
    private bool isReadyToShoot = true;

    public GameObject bulletPrefab;

    public float fireRate;
    protected override void Start()
    {
        base.Start();
        target = GetClosestPlayer().transform;
    }

        private void Update()
    {
        if (isPathDone())
            UpdatePath();

        if (agent.velocity == Vector3.zero && !isForcingRepath)
        {
            isForcingRepath = true;
            StartCoroutine(ForceRepath());
        }
        if (isAbleToShoot())
            StartCoroutine(Shoot());
    }

    private bool isAbleToShoot()
    {
        Ray ray = new Ray();
        RaycastHit hitData;
        ray.direction = (target.position - transform.position).normalized;
        ray.origin = transform.position;
            
        if( Physics.Raycast(ray, out hitData))
        {
            if (hitData.transform.CompareTag("Player") && isReadyToShoot)
                return true;
        }
        return false;
    }

    private IEnumerator Shoot()
    {
        isReadyToShoot = false;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(fireRate);
        isReadyToShoot = true;
    }

    protected override void UpdatePath()
    {
        if (gameObject.activeSelf)
        {
            agent.destination = GetPointToGo();
            Destination = agent.destination;
        }
     
    }
}
