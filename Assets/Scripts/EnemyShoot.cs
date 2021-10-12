using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject Bullet, Player;
    private float tTime;
    [SerializeField] private float WaitTimeToShoot;

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Player.transform.position);
        if (Time.time >= tTime)
        {
            GameObject BulletInstantiate = Instantiate(Bullet, transform.position, Quaternion.identity);
            WaitTimeToShoot = Random.Range(WaitTimeToShoot - 1, WaitTimeToShoot + 1);
            tTime = Time.time + WaitTimeToShoot;
        }
    }
}
