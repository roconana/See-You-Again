using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternManager : MonoBehaviour
{
    public int maxLanternCount = 100;
    public GameObject[] lanternPrefabs;

    private void Start()
    {
        StartCoroutine(SpawnLantern());
        
    }
    IEnumerator SpawnLantern()
    {
        for (int i = 0; i < maxLanternCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 1.0f));
            GameObject clone = Instantiate(lanternPrefabs[Random.Range(0, lanternPrefabs.Length)], new Vector2(Random.Range(-42f, 160f), -10f), Quaternion.identity);
            clone.name = "Clone_" + i;
            clone.GetComponent<Lantern>().speed = Random.Range(1f, 2.8f);
        }
    }

}
