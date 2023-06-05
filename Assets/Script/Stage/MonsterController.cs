using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float speed = 3.0f;
    public float leftBound = -5.0f;
    public float rightBound = 5.0f;
    private int direction = 1; // 1 for right, -1 for left
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        // Check if monster is out of bounds, and reverse direction if so
        if (transform.position.x >= rightBound)
        {
            direction = -1;
            spriteRenderer.flipX = false; // Flip sprite horizontally
        }
        else if (transform.position.x <= leftBound)
        {
            direction = 1;
            spriteRenderer.flipX = true; // Flip sprite horizontally
        }
    }
}

