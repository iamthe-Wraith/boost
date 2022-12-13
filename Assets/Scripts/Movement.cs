using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustForce = 1000f;
    [SerializeField] float rotationForce = 200f;

    Rigidbody rb;
    Movement mvmt;
    Vector2 moveInput;
    bool isThrusting;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mvmt = GetComponent<Movement>();
        audioManager = GetComponent<AudioManager>();
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
        if (isThrusting && mvmt.enabled)
        {
            Vector3 delta = Vector3.up * thrustForce * Time.deltaTime;
            rb.AddRelativeForce(delta);
            audioManager.PlayMainEngineThrust();
        }
        else
        {
            audioManager.Stop();
        }
    }
}
