using UnityEngine;

public class MovingClouds : MonoBehaviour
{
    public float[] speeds;
    public float resetTime = 10f;

    private float[] initialPositions;
    private SpriteRenderer[] sprites;

    private void Start()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
        initialPositions = new float[sprites.Length];

        // Store initial positions of all cloud sprites
        for (int i = 0; i < sprites.Length; i++)
        {
            initialPositions[i] = sprites[i].transform.position.x;
        }
    }

    private void Update()
    {
        // Move cloud sprites to the left at different speeds
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].transform.Translate(Vector2.left * speeds[i] * Time.deltaTime);

            // If a sprite goes off screen, reset its position
            if (sprites[i].transform.position.x < -20f)
            {
                sprites[i].transform.position = new Vector2(initialPositions[i] + 20f, sprites[i].transform.position.y);
            }
        }
    }

    private void OnDisable()
    {
        // Reset initial positions of all cloud sprites when script is disabled
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].transform.position = new Vector2(initialPositions[i], sprites[i].transform.position.y);
        }
    }

    private void OnEnable()
    {
        // Reset initial positions of all cloud sprites when script is enabled
        for (int i = 0; i < sprites.Length; i++)
        {
            initialPositions[i] = sprites[i].transform.position.x;
        }
    }

    private void LateUpdate()
    {
        // Destroy cloud sprites after resetTime seconds
        Invoke("DestroySprites", resetTime);
    }

    private void DestroySprites()
    {
        gameObject.SetActive(false);
    }
}
