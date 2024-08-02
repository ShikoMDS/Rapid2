using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float fMoveSpeed = 5f;
    float fSprintMultiplier = 2.0f;
    public float fJumpPower = 15f;
    public Rigidbody2D rb;
    private SpriteRenderer LookDir;
    float fHorizontalMovement;
    float fCurrentJump;

    public Transform GroundCheck;
    public LayerMask GroundLayer;
    bool bIsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        LookDir = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bIsGrounded = Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(1.0f, 0.2f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
        fHorizontalMovement = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            fHorizontalMovement = fHorizontalMovement * fSprintMultiplier;
        }
        if (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.W) && bIsGrounded)
        {
            fCurrentJump = fJumpPower;
        }
        else
        {
            fCurrentJump = 0;
        }
        rb.velocity = new Vector2(fHorizontalMovement * fMoveSpeed, rb.velocity.y + fCurrentJump);

        // Look direction
        if (rb.velocity.x < 0)
        {
            LookDir.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            LookDir.flipX = false;
        }
    }

}
