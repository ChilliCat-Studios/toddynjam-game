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

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;
        move = move.normalized;

        float speed = moveSpeed;

        if (controller.isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            speed *= 2;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed /= 2;
        }

        if (controller.isGrounded)
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

        velocity.y += gravity * Time.deltaTime;

        move *= speed;
        move.y = velocity.y;
        controller.Move(move * Time.deltaTime);
    }
}
