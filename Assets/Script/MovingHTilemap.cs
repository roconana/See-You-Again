using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHTilemap : MonoBehaviour
{
    public float speed = 3.0f;
    public float leftBound = -5.0f;
    public float rightBound = 5.0f;

    private bool movingRight = true;

    private void Update()
    {
        // Move the tilemap horizontally
        float horizontalMovement = movingRight ? speed : -speed;
        transform.Translate(Vector2.right * horizontalMovement * Time.deltaTime);

        // Check if the tilemap reaches the bounds and change direction
        if (transform.position.x >= rightBound)
        {
            movingRight = false;
        }
        else if (transform.position.x <= leftBound)
        {
            movingRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the player character
        if (collision.gameObject.CompareTag("Player"))
        {
            // Attach the player to the moving platform
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the colliding object is the player character
        if (collision.gameObject.CompareTag("Player"))
        {
            // Detach the player from the moving platform
            collision.collider.transform.SetParent(null);
        }
    }
}
