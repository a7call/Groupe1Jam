using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int playerIndex;
    int GetPlayerIndex()
    {
        return playerIndex;
    }
    private void Update()
    {

    }
    public void Fire(Vector3 dir)
    {
        GameObject InstanciatedBullet = Instantiate(bulletPrefab, firePoint.position,Quaternion.identity);
        InstanciatedBullet.transform.LookAt(InstanciatedBullet.transform.position + dir);
        InstanciatedBullet.GetComponent<Bullets>().direction = dir;
        InstanciatedBullet.GetComponent<Bullets>().origin = this;

        Destroy(InstanciatedBullet, 3f);
    }


}
