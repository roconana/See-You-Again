using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
public class TilemapController : MonoBehaviour
{
    public float disappearTime = 1f; // Time for tilemap to disappear
    public float appearTime = 1f; // Time for tilemap to reappear
    private TilemapRenderer tilemapRenderer;
    private TilemapCollider2D tilemapCollider2D;
    private Animator blinkanimator;

    void Start()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapCollider2D = GetComponent<TilemapCollider2D>();
        blinkanimator = GetComponent<Animator>();
        StartCoroutine(DisappearAndAppear());
    }
    IEnumerator DisappearAndAppear()
    {
        while (true)
        {
            yield return new WaitForSeconds(appearTime);
            // blinkanimator.enabled = true;
            // tilemapRenderer.enabled = false;
            tilemapCollider2D.enabled = false;

            yield return new WaitForSeconds(disappearTime);
            // blinkanimator.enabled = true;
            // tilemapRenderer.enabled = true;
            tilemapCollider2D.enabled = true;
        }
    }
}