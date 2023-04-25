using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageSequence : MonoBehaviour
{
    public Sprite[] sprites;
    public float delay = 0.5f;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(DisplayImages());
    }

    IEnumerator DisplayImages()
    {
        while (true)
        {
            foreach (Sprite sprite in sprites)
            {
                image.sprite = sprite;
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
