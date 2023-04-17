using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private LayerMask collisionMask;                // 플레이어가 발사하는 광선과 부딪히는 레이어 ("Tile")

    [SerializeField]
    private float moveSpeed;                        // 이동속도

    [SerializeField]
    private float jumpForce;                        // 점프 힘
    private Vector3 velocity;                       // 속력 

    [SerializeField]
    private float lowGravity = -15.0f;

    [SerializeField]
    private float highGravity = -40.0f;
    private float gravity = -30.0f;                 // 중력

    private int horizontalRayCount = 4;             // 오브젝트의 좌,우 외곽 광선 개수
    private int verticalRayCount = 4;               // 오브젝트의 위,아래 외곽 광선 개수
    private float horizontalRaySpacing;             // 오브젝트의 좌,우 외곽 광선 사이 간격
    private float verticalRaySpacing;               // 오브젝트의 위,아래 외곽 광선 사이 간격

    private CapsuleCollider2D capsuleCollider2D;
    private ColliderCorner colliderCorner;
    private CollisionChecker collisionChecker;

    private readonly float skinWidth = 0.015f;      // 오브젝트 표면에서 광선을 쏘지 않기 위해 안쪽으로 파고드는 소량의 범위 설정 

    float distance;

    private void Awake()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        CalculateRaySpacing();
    }

    private void Update()
    {
        UpdateColliderCorner();                     // 현재 플레이어의 위치를 기준으로 광선의 생성 위치 설정
        collisionChecker.Reset();                   // 현재 충돌중인 면의 데이터 초기화 

        // 중력
        velocity.y += gravity * Time.deltaTime;
        // 현재 속력에 deltaTime을 곱하여 속력을 구함
        Vector3 currentVelocity = velocity * Time.deltaTime;

        // 속력이 0이 아닐 때 광선을 발사해 이동 가능 여부 조사
        if (currentVelocity.x != 0)
        {
            RaycastsHorizontal(ref currentVelocity);
        }
        if (currentVelocity.y != 0)
        {
            RaycastsVertical(ref currentVelocity);
        }

        // 플레이어 이동
        transform.position += currentVelocity;

        // 천장이나 바닥에 닿아있으면 velocity.y값을 0으로 설정
        if (collisionChecker.up || collisionChecker.down)
        {
            velocity.y = 0;
        }

    }

    private void FixedUpdate()
    {
        if (IsLongJump && velocity.y > 0)
        {
            gravity = lowGravity;
        }
        else
        {
            gravity = highGravity;
        }
    }

    public void Move(float x)
    {
        velocity.x = x * moveSpeed;
    }

    public bool Jump()
    {
        if ( collisionChecker.down )
        {
            velocity.y = jumpForce;

            return true;
        }
        return false;
    }

    public bool IsLongJump
    {
        set; get;
    }

    public CollisionChecker IsCollision
    {
        get { return collisionChecker; }
    }

    public Vector2 Velocity
    {
        get { return velocity; }
    }

    private void RaycastsHorizontal(ref Vector3 velocity)
    {
        float direction = Mathf.Sign(velocity.x);
        float distance = Mathf.Abs(velocity.x) + skinWidth;
        Vector2 rayPosition = Vector2.zero;

        // x축 방향으로 4개의 광선 발사
        for (int i = 0; i < horizontalRayCount; ++i)
        {
            rayPosition = (direction == 1) ? colliderCorner.bottomRight : colliderCorner.bottomLeft;
            rayPosition += Vector2.up * (horizontalRaySpacing * i + velocity.y);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.right * direction, distance, collisionMask);

            if (hit)
            {
                velocity.x = (hit.distance - skinWidth) * direction;
                distance = hit.distance;

                collisionChecker.left = direction == -1;
                collisionChecker.right = direction == 1;
            }

            Debug.DrawLine(rayPosition, rayPosition + Vector2.right * direction * distance, Color.yellow);
        }
    }

    private void RaycastsVertical(ref Vector3 velocity)
    {
        float direction = Mathf.Sign(velocity.y);
        
            distance = Mathf.Abs(velocity.y) + skinWidth;
       
        Vector2 rayPosition = Vector2.zero;

        // x축 방향으로 4개의 광선 발사
        for (int i = 0; i < verticalRayCount; ++i)
        {
            rayPosition = (direction == 1) ? colliderCorner.topLeft : colliderCorner.bottomLeft;
            rayPosition += Vector2.right * (verticalRaySpacing * i + velocity.x);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.up * direction, distance, collisionMask);

            if (hit)
            {
                velocity.y = (hit.distance - skinWidth) * direction;
                distance = hit.distance;

                collisionChecker.up = direction == 1;
                collisionChecker.down = direction == -1;
            }

            Debug.DrawLine(rayPosition, rayPosition + Vector2.up * direction * distance, Color.yellow);
        }
    }

    private void UpdateColliderCorner()
    {
        Bounds bounds = capsuleCollider2D.bounds;
        bounds.Expand(skinWidth * -2);

        colliderCorner.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        colliderCorner.bottomRight = new Vector2(bounds.min.x, bounds.min.y);
        colliderCorner.topLeft = new Vector2(bounds.min.x, bounds.min.y);
    }

     private void CalculateRaySpacing()
     {
            Bounds bounds = capsuleCollider2D.bounds;
            bounds.Expand(skinWidth * -2);

            horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
            verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
     }

    private struct ColliderCorner
    {
        public Vector2 topLeft;
        public Vector2 bottomLeft;
        public Vector2 bottomRight;
    }

    public struct CollisionChecker
    {
        public bool up;
        public bool down;
        public bool left;
        public bool right;

        public void Reset()
        {
            up = false;
            down = false;
            left = false;
            right = false;
        }
    }


    
}