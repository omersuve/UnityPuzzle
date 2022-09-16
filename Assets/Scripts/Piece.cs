using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    GameObject piece;
    Vector3 position;

    void Start()
    {
        piece = GetComponent<GameObject>();
        position = piece.transform.position;
    }

    void Update()
    {
        
    }
}
