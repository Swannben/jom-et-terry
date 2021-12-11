using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public bool whoPlays = true;

    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;

    public Camera mouseCam;
    public Camera PlayerCam;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        if (whoPlays == true) {
            
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0) velocity.y = -2f;

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded) velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        if (Input.GetKeyDown("w"))
        {
            whoPlays = !whoPlays;
            mouseCam.enabled = !mouseCam.enabled;
            PlayerCam.enabled = !PlayerCam.enabled;
        }
    }
}
