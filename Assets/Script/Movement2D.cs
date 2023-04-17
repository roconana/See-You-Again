using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private LayerMask collisionMask;                // �÷��̾ �߻��ϴ� ������ �ε����� ���̾� ("Tile")

    [SerializeField]
    private float moveSpeed;                        // �̵��ӵ�

    [SerializeField]
    private float jumpForce;                        // ���� ��
    private Vector3 velocity;                       // �ӷ� 

    [SerializeField]
    private float lowGravity = -15.0f;

    [SerializeField]
    private float highGravity = -40.0f;
    private float gravity = -30.0f;                 // �߷�

    private int horizontalRayCount = 4;             // ������Ʈ�� ��,�� �ܰ� ���� ����
    private int verticalRayCount = 4;               // ������Ʈ�� ��,�Ʒ� �ܰ� ���� ����
    private float horizontalRaySpacing;             // ������Ʈ�� ��,�� �ܰ� ���� ���� ����
    private float verticalRaySpacing;               // ������Ʈ�� ��,�Ʒ� �ܰ� ���� ���� ����

    private CapsuleCollider2D capsuleCollider2D;
    private ColliderCorner colliderCorner;
    private CollisionChecker collisionChecker;

    private readonly float skinWidth = 0.015f;      // ������Ʈ ǥ�鿡�� ������ ���� �ʱ� ���� �������� �İ��� �ҷ��� ���� ���� 

    float distance;

    private void Awake()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        CalculateRaySpacing();
    }

    private void Update()
    {
        UpdateColliderCorner();                     // ���� �÷��̾��� ��ġ�� �������� ������ ���� ��ġ ����
        collisionChecker.Reset();                   // ���� �浹���� ���� ������ �ʱ�ȭ 

        // �߷�
        velocity.y += gravity * Time.deltaTime;
        // ���� �ӷ¿� deltaTime�� ���Ͽ� �ӷ��� ����
        Vector3 currentVelocity = velocity * Time.deltaTime;

        // �ӷ��� 0�� �ƴ� �� ������ �߻��� �̵� ���� ���� ����
        if (currentVelocity.x != 0)
        {
            RaycastsHorizontal(ref currentVelocity);
        }
        if (currentVelocity.y != 0)
        {
            RaycastsVertical(ref currentVelocity);
        }

        // �÷��̾� �̵�
        transform.position += currentVelocity;

        // õ���̳� �ٴڿ� ��������� velocity.y���� 0���� ����
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

        // x�� �������� 4���� ���� �߻�
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

        // x�� �������� 4���� ���� �߻�
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