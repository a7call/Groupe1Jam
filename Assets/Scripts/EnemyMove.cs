using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private GameObject point1, point2, point3, point4;
    [SerializeField] private float speed;
    private float vpointX, vpointY;

    private void Start()
    {
        vpointX = Random.Range(point1.transform.position.x, point2.transform.position.x);
        vpointY = Random.Range(point3.transform.position.y, point4.transform.position.y);
    }
    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(vpointX, vpointY, 0), speed * Time.deltaTime);

        if (transform.position == new Vector3 (vpointX, vpointY, 0))
        {
            RandomPoint();
        }
    }

    private void RandomPoint ()
    {
        vpointX = Random.Range(point1.transform.position.x, point2.transform.position.x);
        vpointY = Random.Range(point3.transform.position.y, point4.transform.position.y);
    }
}
