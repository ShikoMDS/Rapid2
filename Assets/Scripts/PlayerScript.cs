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
    public int iPoints = 0;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    bool bIsGrounded;

    public GameObject smoke_screen;
    public int smoke_bombs_count = 3;
    private int remaining_smoke_bombs;
    private bool can_smoke = true;

    // Start is called before the first frame update
    void Start()
    {
        LookDir = gameObject.GetComponent<SpriteRenderer>();
        remaining_smoke_bombs = smoke_bombs_count;
    }

    // Update is called once per frame
    void Update()
    {
        bIsGrounded = Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(0.8f, 0.4f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
        fHorizontalMovement = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            fHorizontalMovement = fHorizontalMovement * fSprintMultiplier;
        }
        if ((Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.W)) && bIsGrounded)
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

        // Smoke
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (remaining_smoke_bombs > 0)
            {
                if (can_smoke == true)
                {
                    ActivateSmoke();
                }
            }
        }
    }

    void ActivateSmoke()
    {
        can_smoke = false;
        smoke_screen.SetActive(true);
        remaining_smoke_bombs--;
        Invoke("DeactivateSmoke", 5);
    }

    void DeactivateSmoke()
    {
        smoke_screen.SetActive(false);
        can_smoke = true;
    }
}
