using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Move obstacle toward the player
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Destroy obstacle when it leaves the screen
        if (transform.position.x < -11f)
        {
            Destroy(gameObject);
        }
    }
}

