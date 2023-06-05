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
        // ������Ʈ�� �ʱ� ��ġ�� �����մϴ�.
        startPosition = transform.position;

        // ������ �ӵ��� ������ �����մϴ�.
        floatSpeed = Random.Range(minFloatSpeed, maxFloatSpeed);
        floatRange = Random.Range(minFloatRange, maxFloatRange);

        // ������ �����̸� �����մϴ�.
        randomDelay = Random.Range(0f, 1f);
    }

    private void Update()
    {
        // �����̸� �����Ͽ� ������Ʈ�� ���Ʒ��� �����Դϴ�.
        float newY = startPosition.y + Mathf.Sin((Time.time + randomDelay) * floatSpeed) * floatRange;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
