using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float fMoveSpeed = 5f;
    private float fSprintMultiplier = 2.0f;
    public float fJumpPower = 15f;
    public Rigidbody2D rb;
    private SpriteRenderer LookDir;
    private float fHorizontalMovement;
    private float fCurrentJump;
    public int iPoints = 0;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    private bool bIsGrounded;
    AudioController aAudio;
    // Smoke
    public GameObject smoke_screen;
    public int smoke_bombs_count = 3;
    private int remaining_smoke_bombs;
    private bool can_smoke = true;
    public Image[] m_smoke_images;
    public Sprite m_full_smoke;
    public Sprite m_empty_smoke;

    private Animator animator; // Animator component reference

    // Start is called before the first frame update
    void Start()
    {
        LookDir = gameObject.GetComponent<SpriteRenderer>();
        remaining_smoke_bombs = smoke_bombs_count;
        animator = gameObject.GetComponent<Animator>(); // Get Animator component
        aAudio = FindAnyObjectByType<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        bIsGrounded = Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(0.8f, 0.4f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
        fHorizontalMovement = Input.GetAxisRaw("Horizontal");
        float speed = Mathf.Abs(fHorizontalMovement);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            fHorizontalMovement *= fSprintMultiplier;
        }

        // Changed jump to only use spacebar
        if (Input.GetKeyDown(KeyCode.Space) && bIsGrounded)
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

        ////////////

        if (remaining_smoke_bombs > smoke_bombs_count)
        {
            remaining_smoke_bombs = smoke_bombs_count;
        }

        for (int i = 0; i < m_smoke_images.Length; i++)
        {
            if (i < remaining_smoke_bombs)
            {
                m_smoke_images[i].sprite = m_full_smoke;
            }
            else
            {
                m_smoke_images[i].sprite = m_empty_smoke;
            }

            if (i < smoke_bombs_count)
            {
                m_smoke_images[i].enabled = true;
            }
            else
            {
                m_smoke_images[i].enabled = false;
            }
        }

        ///////////

        // Update animator parameters
        animator.SetFloat("Speed", speed);
        animator.SetBool("IsJumping", !bIsGrounded);
    }

    void ActivateSmoke()
    {
        aAudio.PlaySound(aAudio.SmokeSound);
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
