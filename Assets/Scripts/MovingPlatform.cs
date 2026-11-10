using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f;
    public float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 startingPosition;
    private Vector2 previousPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        previousPosition = rb.position;
    }

    void FixedUpdate()
    {
        float movement = Mathf.PingPong(
            Time.time * moveSpeed,
            moveDistance * 2f
        ) - moveDistance;

        Vector2 targetPosition = startingPosition +
            Vector2.right * movement;

        rb.MovePosition(targetPosition);

        Vector2 platformMovement = targetPosition - previousPosition;

        // Carry the player if one is standing on this platform
        if (playerOnPlatform != null)
        {
            playerOnPlatform.position +=
                (Vector3)platformMovement;
        }

        previousPosition = targetPosition;
    }

    private Transform playerOnPlatform;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = collision.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = null;
        }
    }
}
