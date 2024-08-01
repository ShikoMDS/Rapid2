using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform[] patrolPoints;
    private int currentPoint = 0;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (patrolPoints.Length > 0)
        {
            transform.position = patrolPoints[currentPoint].position;
        }
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.0f, 0.2f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (isGrounded)
        {
            Patrol();
        }

        // Flip sprite based on movement direction
        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        // Move towards the current patrol point
        Vector2 targetPosition = patrolPoints[currentPoint].position;
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.deltaTime);
        rb.MovePosition(newPosition);

        // Check if the enemy has reached the patrol point
        if (Vector2.Distance(rb.position, targetPosition) < 0.2f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }
}