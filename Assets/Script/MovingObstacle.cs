using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float minY; // Minimum y-coordinate
    public float maxY; // Maximum y-coordinate
    public float speed; // Movement speed

    private bool movingUp = true; // Flag to track the movement direction

    private void Start()
    {
        // Set the initial position to the minimum y-coordinate value
        transform.position = new Vector3(transform.position.x, minY, transform.position.z);
    }

    private void Update()
    {
        // Calculate the target position based on the current movement direction
        float targetY = movingUp ? maxY : minY;
        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the object reached the target position
        if (Mathf.Approximately(transform.position.y, targetY))
        {
            // Switch the movement direction
            movingUp = !movingUp;
        }
    }
}
