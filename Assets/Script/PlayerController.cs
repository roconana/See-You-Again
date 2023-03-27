using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;
    private Movement2D movement2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateMove();
        UpdateJump();
    }

    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");

        movement2D.Move(x);
        UpdateAnimation(x);
    }

    private void UpdateAnimation(float x)
    {
        if (x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (x > 0)
        {
            spriteRenderer.flipX = false;
        }

        // �ٴڿ� ���������
        if (movement2D.IsCollision.down)
        {
            if(animator.GetBool("isJump"))
            {
                animator.SetBool("isJump", false);
            }

            //movement�� 0�̸� "Idle", movement�� 1�̸� "Run" ���
            animator.SetFloat("movement", Mathf.Abs(x));
        }

        // �ٴڿ� �������������
        else
        {
            if (!animator.GetBool("isJump"))
            {
                animator.SetBool("isJump", true);
            }
        }
    }

    private void UpdateJump()
    {
        if (Input.GetKeyDown(jumpKeyCode) )
        {
            bool isJump = movement2D.Jump();

            if (isJump)
            {
                //���� ���� �� �� �ൿ 
            }
        }

        if (Input.GetKey(jumpKeyCode) )
        {
            movement2D.IsLongJump = true;
        }

        else if (Input.GetKeyUp(jumpKeyCode))
        {
            movement2D.IsLongJump = false;
        }
    }
}
