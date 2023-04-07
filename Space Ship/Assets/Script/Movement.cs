using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    float speed = 1000f;
    float RotateSpeed = 180f;
    AudioSource thrustingST;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrustingST = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioThrust();
    }

    private void FixedUpdate()
    {
        ThrustingShip();
        RotateShip();
    }

    void ThrustingShip()
    {
        if (Input.GetButton("Jump"))
        {
            rb.AddRelativeForce(Vector3.up  * speed * Time.deltaTime);
        }
        
    }

    void AudioThrust()
    {
        if (Input.GetButtonDown("Jump")) { 
            thrustingST.Play();
        }
        if (Input.GetButtonUp("Jump"))
        {
            thrustingST.Stop();
        }

    }

    void RotateShip()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyTheRotation(RotateSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ApplyTheRotation(-RotateSpeed);
        }

    }

    void ApplyTheRotation(float Rotate)
    {
        Vector3 zInput = Vector3.forward * Time.deltaTime * Rotate;
        rb.freezeRotation = true;
        transform.Rotate(zInput);
        rb.freezeRotation = false;
    }
}