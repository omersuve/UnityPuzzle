using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _width = 6;
    [SerializeField] private int _height = 6;
    [SerializeField] private Node _nodePrefab;
    [SerializeField] private bool isEasy = true;

    private GameObject selectedPiece;
    public int Score;
    private Graph g;
    private List<Edge> resultedListEdges;

    void Start()
    {
        g = new Graph(16);

        g.addRandomWeigths();

        g.Kruskals_MST(g.edges, g.vertexList);

        g.findTreeEdges();

        g.randomDeletion();

        foreach (Edge edge in g.listOfDeletedEdges)
        {
            Debug.Log("***************");
            g.DFS_for_tree(edge.vertexId1);
            Debug.Log("***************");
            g.DFS_for_tree(edge.vertexId2);
        }

        //GenerateGrid();
        //DrawUpwards(Color.red);
        //DrawRight(Color.cyan);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Piece"))
            {
                selectedPiece = hit.transform.gameObject;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedPiece = null;
        }

        if(selectedPiece != null)
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedPiece.transform.position = new Vector3(mousePoint.x, mousePoint.y, 0);
        }
    }

    void GenerateGrid()
    {
        for(int i = 0; i < _width; i++)
        {
            for(int j = 0; j < _height; j++)
            {
               
            }
        }
    }

    void DrawLine(Vector2 start, Vector2 end, Color color, float duration = 15f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        //GameObject.Destroy(myLine, duration);
    }


    void DrawUpwards(Color color)
    {
        int valY = 0;
        int valX = Random.Range(0, _width / 2 + 1) * 2;
        var initPositionX = new Vector2(valX, valY);
        while (valY < _height)
        {
            initPositionX = new Vector2((float)(valX - 0.5), (float)(valY - 0.5));

            if (valX == 0)
            {
                valX = Random.Range(0, 2) * 2;
            }
            else if (valX == _width)
            {
                valX = Random.Range(_width / 2 - 1, _width / 2 + 1) * 2;
            }
            else
            {
                valX = Random.Range(valX / 2 - 1, valX / 2 + 2) * 2;
            }


            valY += 2;

            var targetPosition1 = new Vector2((float)(valX - 0.5), (float)(valY - 0.5));
            DrawLine(initPositionX, targetPosition1, color);
        }
    }

    void DrawRight(Color color)
    {
        int valX = 0;
        int valY = Random.Range(0, _height / 2 + 1) * 2;
        var initPositionY = new Vector2(valX, valY);
        while (valX < _width)
        {
            initPositionY = new Vector2((float)(valX - 0.5), (float)(valY - 0.5));

            if (valY == 0)
            {
                valY = Random.Range(0, 2) * 2;
            }
            else if (valY == _height)
            {
                valY = Random.Range(_height / 2 - 1, _height / 2 + 1) * 2;
            }
            else
            {
                valY = Random.Range(valY / 2 - 1, valY / 2 + 2) * 2;
            }

            valX += 2;

            var targetPosition2 = new Vector2((float)(valX - 0.5), (float)(valY - 0.5));
            DrawLine(initPositionY, targetPosition2, color);
        }
    }
}
