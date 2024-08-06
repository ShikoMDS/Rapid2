using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform[] patrolPoints;
    private int currentPoint = 0;

    private Rigidbody2D rb;
    private bool isAtPoint = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (patrolPoints.Length > 0)
        {
            transform.position = patrolPoints[currentPoint].position;
        }
        Debug.Log("Start position set to patrol point " + currentPoint);
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        if (!isAtPoint)
        {
            MoveToNextPoint();
        }
    }

    void MoveToNextPoint()
    {
        Vector2 targetPosition = patrolPoints[currentPoint].position;
        rb.MovePosition(Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime));

        Debug.Log("Moving towards point " + currentPoint + " at position " + targetPosition);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            isAtPoint = true;
            Debug.Log("Reached point " + currentPoint);
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
            isAtPoint = false;
        }
    }
}
