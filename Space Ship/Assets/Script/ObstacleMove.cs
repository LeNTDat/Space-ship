using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{

    Vector3 startPos;
    [SerializeField] Vector3 MovementVector;
    [SerializeField] [Range(0,1)] float MovementFactor;
    [SerializeField] float period;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObj();

    }

    void MoveObj() 
    {
        if(period <= Mathf.Epsilon) { return; }
        float circle = Time.time / period;
        float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(circle * tau);
        MovementFactor = (rawSinWave + 1f) / 2f;
        Vector3 offset = MovementVector * MovementFactor;
        transform.position = startPos + offset;
    }
}
