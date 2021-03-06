using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float jumpHeight = 2f;
    private float deadzone = 0.25f;

    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);   

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        
        Vector2 touchCoords = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);


//        float x = Input.GetAxis("Horizontal");
//        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * touchCoords.x + transform.forward* touchCoords.y;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}
