using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingClouds : MonoBehaviour
{
    // Public variables to set in the inspector
    public float leftRangeMin = 1f;
    public float leftRangeMax = 2f;
    public float teleportCoord = -10f;

    // Private variables
    private Vector3[] cloudPositions; // Array to store initial positions of clouds
    private float[] cloudSpeeds; // Array to store random speeds for each cloud

    // Start is called before the first frame update
    void Start()
    {
        // Get the initial positions of all clouds
        cloudPositions = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            cloudPositions[i] = transform.GetChild(i).transform.position;
        }

        // Generate random speeds for each cloud
        cloudSpeeds = new float[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            cloudSpeeds[i] = Random.Range(leftRangeMin, leftRangeMax);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move each cloud to the left at its own speed
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform cloud = transform.GetChild(i).transform;
            Vector3 newPos = cloud.position - Vector3.right * cloudSpeeds[i] * Time.deltaTime;
            cloud.position = newPos;

            // Teleport the cloud back to its starting position if it reaches the teleport coordinate
            if (cloud.position.x <= teleportCoord)
            {
                cloud.position = cloudPositions[i];
            }
        }
    }
}
