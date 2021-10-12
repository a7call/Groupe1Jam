using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private float vpointX, vpointY;
    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        vpointX = Random.Range(transform.position.x - 5, transform.position.x + 5);
        vpointY = Random.Range(transform.position.y - 5, transform.position.y + 5);
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
        vpointX = Random.Range(initialPosition.x - 5, initialPosition.x + 5);
        vpointY = Random.Range(initialPosition.y - 5, initialPosition.y + 5);
    }
}
