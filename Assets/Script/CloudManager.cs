using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public int maxClouldCount = 20;
    public GameObject[] cloudPrefabs;
    private void Start()
    {
        StartCoroutine(SpwanCloud());
        
    }

    IEnumerator SpwanCloud()
    {
        for (int i = 0; i < maxClouldCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            GameObject clone = Instantiate(cloudPrefabs[Random.Range(0, cloudPrefabs.Length)], new Vector2(126, Random.Range(-6f, 4.5f)), Quaternion.identity);
            clone.name = "Clone_" + i;
            clone.GetComponent<Cloud>().speed = Random.Range(1f, 3f);
        }
    }

}
