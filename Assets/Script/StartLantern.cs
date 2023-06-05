using UnityEngine;

public class StartLantern : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y > 1200f)
        {
            transform.position = new Vector2(Random.Range(0f, 1920f), -10f);
            speed = Random.Range(25f, 45f);
        }
    }
}
