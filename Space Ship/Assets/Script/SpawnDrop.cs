using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDrop : MonoBehaviour
{
    public GameObject stone;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        InvokeRepeating("SpawnDropStone", 1f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.canMove)
        {
            CancelInvoke("SpawnDropStone");
        }
    }

    void SpawnDropStone () 
    {
        pos.x = Random.Range(-18f,18f );
        Instantiate(stone, pos, stone.gameObject.transform.rotation);
    }
}
