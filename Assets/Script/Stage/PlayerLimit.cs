using UnityEngine;

public class PlayerLimit : MonoBehaviour
{
    public float minX;
    public float maxX;

    private float playerHalfWidth;

    private void Start()
    {
        // 플레이어의 반 폭을 스프라이트나 콜라이더 크기를 기반으로 계산합니다.
        playerHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    private void Update()
    {
        // 수평 입력을 받습니다.
        float horizontalInput = Input.GetAxis("Horizontal");

        // 목표 위치를 계산합니다.
        float targetX = transform.position.x + horizontalInput * Time.deltaTime;
        targetX = Mathf.Clamp(targetX, minX + playerHalfWidth, maxX - playerHalfWidth);

        // 플레이어를 목표 위치로 이동합니다.
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
