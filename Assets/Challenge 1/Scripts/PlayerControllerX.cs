using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Added this for input on Xbox Controller

/// <summary>
/// I did some testing and found a solution. When the plane collides the physics engine 
/// inputs a rotational force on the plane that will slowly dissipate over time based on 
/// the Angular Damping property. You can update the RigidBody Angular Damping from .05 to 
/// 1 which will stop this force almost immediately after collision
/// </summary>

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

    public float horizontalInput;

    //increment speed based on input
    public float acceleration = 10f;

    //Need range for speed to prevent plane from going too fast or too slow
    public float minSpeed = 10f;
    public float maxSpeed = 120f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

       if(Gamepad.current != null)
        {
            //switched cause float was unsupported for reading the left stick value.
            // Now using Vector2 to read the left stick value
            Vector2 leftStick = Gamepad.current.leftStick.ReadValue();
            verticalInput += leftStick.y;
            horizontalInput += leftStick.x;
        }

        verticalInput = Mathf.Clamp(verticalInput, -1f, 1f);
        horizontalInput = Mathf.Clamp(horizontalInput, -1f, 1f);

        // increment speed based on vertical input
        // set bounds for plane speed to prevent it from going too fast or too slow
        speed += horizontalInput * acceleration * Time.deltaTime;
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);


        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // tilt the plane up/down based on up/down input
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
        
    }
}
