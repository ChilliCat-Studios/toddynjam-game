using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float moveSpeed = 6f;
    public float gravity = -19.82f;
    public float jumpHeight = 3f;
    

    public Transform groundCheck;
    public float groundDistance = 0.6f;


    private Vector3 velocity;
    private float lastSpeed;
    private Vector3 jumpForward;
    private bool isStraifing;
    private bool isBackwards;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        move = move.normalized;


        if (controller.isGrounded)
        {
            move = transform.right * x + transform.forward * z;
            move = move.normalized;
            CalculateMoveDirection(move);

            move = SetMoveSpeed(move);
            if (CheckJump())
            {
                jumpForward = transform.forward * z;
            }
            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }
        else if(jumpForward.Equals(Vector3.zero))
        {
            move = Vector3.zero;
        }
        else
        {
            
            float dot = Vector3.Dot(jumpForward, move);
            Debug.Log(dot);
            if(dot < 0)
            {
                move = jumpForward;
            }
            else
            {
                move = transform.right * x + jumpForward;
            }
            move = move.normalized;
            move *= lastSpeed;
        }

        velocity.y += gravity * Time.deltaTime;
        move.y = velocity.y;
        controller.Move(move * Time.deltaTime);
    }

    private void CalculateMoveDirection(Vector3 move)
    {
        if (Vector3.Dot(move, transform.forward) < -.5f)
        {
            isBackwards = true;
            isStraifing = false;
        }
        else if (Vector3.Dot(move, transform.forward) < .5f)
        {
            isStraifing = true;
            isBackwards = false;
        }
        else
        {
            isBackwards = false;
            isStraifing = false;
        }
    }

    private bool CheckJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            return true;
        }
        return false;
    }

    private Vector3 SetMoveSpeed(Vector3 move)
    {
        float speed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= 2;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed /= 2;
        }
        lastSpeed = speed;
        move *= speed;
        return move;
    }
}
