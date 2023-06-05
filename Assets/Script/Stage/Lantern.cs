using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y > 7f)
        {
            transform.position = new Vector2(Random.Range(-42f, 160f), -10f);
            speed = Random.Range(1f, 2f);
        }
    }
}
