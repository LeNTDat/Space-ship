using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
    }
}
