using UnityEngine;

public class PlayerLimit : MonoBehaviour
{
    public float minX;
    public float maxX;

    private float playerHalfWidth;

    private void Start()
    {
        // �÷��̾��� �� ���� ��������Ʈ�� �ݶ��̴� ũ�⸦ ������� ����մϴ�.
        playerHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    private void Update()
    {
        // ���� �Է��� �޽��ϴ�.
        float horizontalInput = Input.GetAxis("Horizontal");

        // ��ǥ ��ġ�� ����մϴ�.
        float targetX = transform.position.x + horizontalInput * Time.deltaTime;
        targetX = Mathf.Clamp(targetX, minX + playerHalfWidth, maxX - playerHalfWidth);

        // �÷��̾ ��ǥ ��ġ�� �̵��մϴ�.
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
