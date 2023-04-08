using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    float speed = 1000f;
    float RotateSpeed = 180f;
    AudioSource thrustingST;
    [SerializeField] ParticleSystem booster;
    [SerializeField] ParticleSystem LsideBooster;
    [SerializeField] ParticleSystem RsideBooster;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrustingST = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GameManager.instance.canMove)
        {
            ThrustingShip();
            RotateShip();
        }
    }

    void ThrustingShip()
    {
        if (Input.GetButton("Jump"))
        {
            rb.AddRelativeForce(Vector3.up  * speed * Time.deltaTime);
            if (!thrustingST.isPlaying)
            {
                thrustingST.Play();
            }
            if (!booster.isPlaying)
            {
                booster.Play();
            }
        }
        else
        {
            thrustingST.Stop();
            booster.Stop();
        }
        
    }

    void RotateShip()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyTheRotation(RotateSpeed);
            if(!RsideBooster.isPlaying)
            {
                RsideBooster.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyTheRotation(-RotateSpeed);
            if (!LsideBooster.isPlaying)
            {
                LsideBooster.Play();
            }
        }
        else
        {
            RsideBooster.Stop();
            LsideBooster.Stop();
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