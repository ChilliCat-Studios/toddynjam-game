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
    private Vector3 lastDirection;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        move = move.normalized;
        
        


        if (controller.isGrounded)
        {
            move = SetMoveSpeed(move);
            UpdateVerticalMovement();
        }
        else
        {
            move = lastDirection;
        }

        velocity.y += gravity * Time.deltaTime;
        move.y = velocity.y;
        controller.Move(move * Time.deltaTime);
    }

    private void UpdateVerticalMovement()
    {
        if (velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
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

        move *= speed;
        lastDirection = move;
        return move;
    }
}
