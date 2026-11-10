using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Death Settings")]
    public float deathY = -10f;
    
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private int jumpsRemaining;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        // Move left and right
        float moveX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(
            moveX * moveSpeed,
            rb.velocity.y
        );

        // Jump using Up Arrow, W, or Spacebar
        if ((Input.GetKeyDown(KeyCode.UpArrow) ||
             Input.GetKeyDown(KeyCode.W) ||
             Input.GetKeyDown(KeyCode.Space))
             && jumpsRemaining > 0)
        {
            Jump();
        }

        CheckForFall();
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        jumpsRemaining--;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        CheckGroundCollision(collision);
    }

    void CheckGroundCollision(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            ContactPoint2D contact = collision.GetContact(i);

            // Only reset jumps when touching the top of a surface
            if (contact.normal.y > 0.5f)
            {
                jumpsRemaining = maxJumps;
                return;
            }
        }
    }
    void CheckForFall()
    {
        if (transform.position.y < deathY)
        {
            Debug.Log("Player fell off the platform!");
            Destroy(gameObject);
        }
    }
}
