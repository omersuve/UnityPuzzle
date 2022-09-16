using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public GameObject piece;
    public Vector3 position;

    void Start()
    {
        piece = GetComponent<GameObject>();
        position = piece.transform.position;
    }

    void Update()
    {
        
    }
}
