using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float moveSpeed = 6f;
    public float straifSpeed = 4f;
    public float backwardSpeed = 2f;
    public float gravity = -19.82f;
    public float jumpHeight = 3f;
    

    public Transform groundCheck;
    public float groundDistance = 0.6f;


    private Vector3 velocity;
    private float lastSpeed;
    private Vector3 jumpForward;
    private bool isStraifing;
    private bool isBackwards;
    private float moveDir;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        move = move.normalized;


        if (controller.isGrounded)
        {
            CalculateMoveDirection(move, transform.forward);

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
        else if (isStationaryJump())
        {
            move = Vector3.zero;
        }
        else
        {
            CalculateMoveDirection(move, jumpForward);

            if (moveDir < 0)
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

    private bool isStationaryJump()
    {
        return jumpForward.Equals(Vector3.zero);
    }

    private void CalculateMoveDirection(Vector3 move, Vector3 forward)
    {
        moveDir = Vector3.Dot(move, forward);

        if (moveDir < -.5f)
        {
            isBackwards = true;
            isStraifing = false;
        }
        else if (moveDir < .5f)
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
        float speed;
        if(isBackwards)
        {
            speed = backwardSpeed;
        }
        else if (isStraifing)
        {
            speed = straifSpeed;
        }
        else
        {
            speed = moveSpeed;
        }

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
