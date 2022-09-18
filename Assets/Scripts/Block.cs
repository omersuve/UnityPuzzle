using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Vector3 RightPos;
    public bool isInRightPos = false;
    public List<Vector3> locations;
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
        if (Vector3.Distance(transform.position, RightPos) < 0.5f)
        {
            isInRightPos = true;
        }else
        {
            isInRightPos = false;
        }
        //if (Vector3.Distance(transform.position, loc) < 0.5f)
        //{
        //    transform.position = loc;
        //}
    }
}
