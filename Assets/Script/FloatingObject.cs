using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float minFloatSpeed = 1.0f;
    public float maxFloatSpeed = 3.0f;
    public float minFloatRange = 10.0f;
    public float maxFloatRange = 30.0f;

    private Vector3 startPosition;
    private float floatSpeed;
    private float floatRange;
    private float randomDelay;

    private void Start()
    {
        // 오브젝트의 초기 위치를 저장합니다.
        startPosition = transform.position;

        // 랜덤한 속도와 범위를 설정합니다.
        floatSpeed = Random.Range(minFloatSpeed, maxFloatSpeed);
        floatRange = Random.Range(minFloatRange, maxFloatRange);

        // 랜덤한 딜레이를 설정합니다.
        randomDelay = Random.Range(0f, 1f);
    }

    private void Update()
    {
        // 딜레이를 적용하여 오브젝트를 위아래로 움직입니다.
        float newY = startPosition.y + Mathf.Sin((Time.time + randomDelay) * floatSpeed) * floatRange;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
