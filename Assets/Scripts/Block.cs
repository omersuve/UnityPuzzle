using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Vector3 RightPos;
    public bool isInRightPos = false;
    public List<Vector3> locations;
    public bool selected;
    void Start()
    {
        RightPos = transform.position;
        transform.position = new Vector3 (Random.Range(6f,8f), Random.Range(-2f, 2f));
        //GameObject[] pieceList = GameObject.FindGameObjectsWithTag("Piece");
        //foreach (GameObject piece in pieceList)
        //{
        //    locations.Add(piece.transform.position);
        //    piece.AddComponent<Piece>();
        //}
    }

    void Update()
    {
        Debug.Log(RightPos);
        Debug.Log(transform.position);
        if (!selected)
        {
            if (Vector3.Distance(transform.position, Vector3.zero) < 0.5f)
                transform.position = Vector3.zero;
                //isInRightPos = true;
            else if (Vector3.Distance(transform.position, Vector3.zero + new Vector3(2, 2, 0)) < 0.5f)
                transform.position = Vector3.zero + new Vector3(2, 2, 0);
            else if (Vector3.Distance(transform.position, Vector3.zero + new Vector3(4, 4, 0)) < 0.5f)
                transform.position = Vector3.zero + new Vector3(4, 4, 0);
            else if (Vector3.Distance(transform.position, Vector3.zero + new Vector3(-4, -4, 0)) < 0.5f)
                transform.position = Vector3.zero + new Vector3(-4, -4, 0);
            else if (Vector3.Distance(transform.position, Vector3.zero + new Vector3(-2, -2, 0)) < 0.5f)
                transform.position = Vector3.zero + new Vector3(-2, -2, 0);
            else if (Vector3.Distance(transform.position, Vector3.zero + new Vector3(-4, -2, 0)) < 0.5f)
                transform.position = Vector3.zero + new Vector3(-4, -2, 0);
            else if (Vector3.Distance(transform.position, Vector3.zero + new Vector3(0, -4, 0)) < 0.5f)
                transform.position = Vector3.zero + new Vector3(0, -4, 0);
            else if (Vector3.Distance(transform.position, Vector3.zero + new Vector3(-2, -4, 0)) < 0.5f)
                transform.position = Vector3.zero + new Vector3(-2, -4, 0);
            else if (Vector3.Distance(transform.position, Vector3.zero + new Vector3(4, 0, 0)) < 0.5f)
                transform.position = Vector3.zero + new Vector3(4, 0, 0);
            else if (Vector3.Distance(transform.position, Vector3.zero + new Vector3(0, 2, 0)) < 0.5f)
                transform.position = Vector3.zero + new Vector3(0, 2, 0);
            else if (Vector3.Distance(transform.position, Vector3.zero + new Vector3(-4, 2, 0)) < 0.5f)
                transform.position = Vector3.zero + new Vector3(-4, 2, 0);
            else if (Vector3.Distance(transform.position, Vector3.zero + new Vector3(2, 0, 0)) < 0.5f)
                transform.position = Vector3.zero + new Vector3(2, 0, 0);
            else if (Vector3.Distance(transform.position, Vector3.zero + new Vector3(0, -6, 0)) < 0.5f)
                transform.position = Vector3.zero + new Vector3(0, -6, 0);
            else
            {
            }
        }
            //isInRightPos = false;
        //if (Vector3.Distance(transform.position, loc) < 0.5f)
        //{
        //    transform.position = loc;
        //}
    }
}
