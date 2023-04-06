using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    int speed = 1;
    float yPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveShip();
    }

    void MoveShip()
    {
        if (Input.GetButtonDown("Jump"))
        {
            yPos += speed; 
            rb.velocity = new Vector3(0, yPos, 0);
        }
    }
}
