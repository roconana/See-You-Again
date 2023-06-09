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

    public Vector2 teleportPosition;


    public bool isDontMove;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isDontMove = true;
    }

    private void Update()
    {
        if(isDontMove)
        {
            UpdateMove();
            UpdateJump();
        }
        // Check if the T button is pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Set the player's position to the desired coordinates
            transform.position = teleportPosition;
        }

        UpdateTalk();
    }

    public void MoveCtrl()
    {
        isDontMove = !isDontMove;
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

        // 바닥에 닿아있으면
        if (movement2D.IsCollision.down)
        {
            if(animator.GetBool("isJump"))
            {
                animator.SetBool("isJump", false);
            }

            //movement가 0이면 "Idle", movement가 1이면 "Run" 재생
            animator.SetFloat("movement", Mathf.Abs(x));
        }

        // 바닥에 닿아있지않으면
        else
        {
            if (!animator.GetBool("isJump"))
            {
                animator.SetBool("isJump", true);
            }

            animator.SetFloat("jump", Mathf.Sign(movement2D.Velocity.y));
        }
    }

    private void UpdateTalk()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetFloat("movement", 0);
            movement2D.ResetVelocity();
            currentNPC?.StartDialog();
        }
    }

    private void UpdateJump()
    {
        if (Input.GetKeyDown(jumpKeyCode) )
        {
            bool isJump = movement2D.Jump();

            if (isJump)
            {
                //점프 성공 시 할 행동 
                animator.SetBool("isJump", true);
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

    private NPC currentNPC = null;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<NPC>(out NPC npc)) return;

        currentNPC = npc;
    }
}
