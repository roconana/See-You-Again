
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLanternManager : MonoBehaviour
{
    public int maxLanternCount = 100;
    public GameObject[] lanternPrefabs;
    public Transform parentTransform; // �θ� ��ü�� Transform

    public float spawnXMin = 0f;
    public float spawnXMax = 1920f;
    public float spawnY = -10f;

    private void Start()
    {
        StartCoroutine(SpawnLantern());
    }

    IEnumerator SpawnLantern()
    {
        for (int i = 0; i < maxLanternCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            GameObject clone = Instantiate(lanternPrefabs[Random.Range(0, lanternPrefabs.Length)], new Vector2(Random.Range(spawnXMin, spawnXMax), spawnY), Quaternion.identity);
            clone.name = "Clone_" + i;
            clone.GetComponent<StartLantern>().speed = Random.Range(25f, 45f);

            // Ŭ���� �θ� ��ü�� ������ ����
            clone.transform.SetParent(parentTransform);
        }
    }
}
