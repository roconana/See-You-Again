using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;
    private Movement2D movement2D;

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
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
    }

    private void UpdateJump()
    {
        if (Input.GetKeyDown(jumpKeyCode) )
        {
            bool isJump = movement2D.Jump();

            if (isJump)
            {
                //점프 성공 시 할 행동 
            }
        }

        if (Input.GetKey(jumpKeyCode) )
        {
            movement2D.IsJump = true;
        }

        else if (Input.GetKeyUp(jumpKeyCode))
        {
            movement2D.IsJump = false;
        }
    }
}
