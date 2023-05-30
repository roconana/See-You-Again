using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingVTilemap : MonoBehaviour
{
    public float speed = 3.0f;
    public float topBound = 5.0f;
    public float bottomBound = -5.0f;

    private bool movingUp = true;

    private void Update()
    {
        // Move the tilemap vertically
        float verticalMovement = movingUp ? speed : -speed;
        transform.Translate(Vector2.up * verticalMovement * Time.deltaTime);

        // Check if the tilemap reaches the bounds and change direction
        if (transform.position.y >= topBound)
        {
            movingUp = false;
        }
        else if (transform.position.y <= bottomBound)
        {
            movingUp = true;
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
