using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector2.right * -1 * speed * Time.deltaTime);
        if(transform.position.x < -60f)
        {
            transform.position = new Vector2(126f, Random.Range(-6f, 6));
            speed = Random.Range(1f, 2f);
        }
    }
}
