using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public int maxCloudCount = 20;
    public GameObject[] cloudPrefabs;

    private void Start()
    {
        StartCoroutine(SpawnCloud());
        
    }

    IEnumerator SpawnCloud()
    {
        for (int i = 0; i < maxCloudCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            GameObject clone = Instantiate(cloudPrefabs[Random.Range(0, cloudPrefabs.Length)], new Vector2(140, Random.Range(-6f, 4.5f)), Quaternion.identity);
            clone.name = "Clone_" + i;
            clone.GetComponent<Cloud>().speed = Random.Range(1f, 3f);
        }
    }

}
