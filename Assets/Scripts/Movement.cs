using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustForce = 1000f;
    [SerializeField] float rotationForce = 200f;

    Rigidbody rb;
    Vector2 moveInput;
    bool isThrusting;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Thrust();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnThrust(InputValue value)
    {
        isThrusting = value.isPressed;
    }

    private void Move()
    {
        rb.freezeRotation = true;
        Vector3 delta = Vector3.forward * rotationForce * -moveInput.x * Time.deltaTime;
        transform.Rotate(delta);
        rb.freezeRotation = false;
    }
    

    private void Thrust()
    {
        if (isThrusting)
        {
            Vector3 delta = Vector3.up * thrustForce * Time.deltaTime;
            rb.AddRelativeForce(delta);
        }
    }
}
