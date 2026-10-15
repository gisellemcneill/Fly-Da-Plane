using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("Movement Settings")]
    public float speed = 5.0f;
    public float turnSpeed = 5f;

    //Input System action exposed in Inspector for binding keys
    public InputAction MoveAction;
    
    //Current input value (x = horizontal, y = vertical), kept private for internal use
    public Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Enable MoveAction to allow for input reading
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //Read 2D vector from MoveAction input (x: horizontal, y: vertical)
        moveInput = MoveAction.ReadValue<Vector2>();
        
        //Move player forward and backward along local Z using y component
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);

        //Rotate around local y using x component
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);
    }
}
