using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternManager : MonoBehaviour
{
    public int maxLanternCount = 100;
    public GameObject[] lanternPrefabs;
    public float spawnXMin = -42f;
    public float spawnXMax = 160f;
    public float spawnY = -10f;

    private void Start()
    {
        StartCoroutine(SpawnLantern());
    }

    IEnumerator SpawnLantern()
    {
        for (int i = 0; i < maxLanternCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            GameObject clone = Instantiate(lanternPrefabs[Random.Range(0, lanternPrefabs.Length)], new Vector2(Random.Range(spawnXMin, spawnXMax), spawnY), Quaternion.identity);
            clone.name = "Clone_" + i;
            clone.GetComponent<Lantern>().speed = Random.Range(1f, 2.5f);
        }
    }
}
