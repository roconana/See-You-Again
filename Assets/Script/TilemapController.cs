using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
public class TilemapController : MonoBehaviour
{
    public float disappearTime = 1f; // Time for tilemap to disappear
    public float appearTime = 1f; // Time for tilemap to reappear
    private TilemapRenderer tilemapRenderer;
    private TilemapCollider2D tilemapCollider2D;
    private bool isVisible = true;
    void Start()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapCollider2D = GetComponent<TilemapCollider2D>();
        StartCoroutine(DisappearAndAppear());
    }
    IEnumerator DisappearAndAppear()
    {
        while (true)
        {
            yield return new WaitForSeconds(appearTime);
            tilemapRenderer.enabled = false;
            tilemapCollider2D.enabled = false;
            isVisible = false;

            yield return new WaitForSeconds(disappearTime);
            tilemapRenderer.enabled = true;
            tilemapCollider2D.enabled = true;
            isVisible = true;
        }
    }
}