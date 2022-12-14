using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;

    float movementFactor;
    Vector3 startingPosition;
    
    void Start()
    {
        startingPosition = transform.position;    
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; };

        // https://www.udemy.com/course/unitycourse2/learn/lecture/24879870
        // https://en.wikipedia.org/wiki/Sine_and_cosine
        // https://en.wikipedia.org/wiki/Turn_(angle)
        float cycles = Time.time / period; 

        const float tau = Mathf.PI * 2; // 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // -1-1
        movementFactor = (rawSinWave + 1f) / 2f; // converts ^ to 0-1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
