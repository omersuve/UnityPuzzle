using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Vector3 RightPos;
    public bool isInRightPos = false;
    void Start()
    {
        RightPos = transform.position;
        transform.position = new Vector3 (Random.Range(4f,6f), Random.Range(-3f, 3f));
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, RightPos) < 0.5f)
        {
            transform.position = RightPos;
            isInRightPos = true;
        }
    }
}
