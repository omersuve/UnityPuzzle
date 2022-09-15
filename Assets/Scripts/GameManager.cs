using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private List<HashSet<int>> resblocks;

    void Start()
    {
        g = new Graph(16);

        g.addRandomWeigths();

        g.Kruskals_MST(g.edges, g.vertexList);

        g.findTreeEdges();

        g.randomDeletion();
        int k = 0;
        for (int i = 0; i < g.listOfDeletedEdges.Count; i++)
        {
            g.blocks.Add(new HashSet<int>());
            Debug.Log("***************");
            g.DFS_for_tree(g.listOfDeletedEdges[i].vertexId1, k);
            g.blocks.Add(new HashSet<int>());
            Debug.Log("***************");
            g.DFS_for_tree(g.listOfDeletedEdges[i].vertexId2, k+1);
            k += 2;
        }

        resblocks = CopyList(g.blocks);

        for(int i = 0; i < g.blocks.Count-1; i++)
        {
            for(int j = i+1; j < g.blocks.Count; j++)
            {
                if (g.blocks[i].SetEquals(g.blocks[j]))
                {
                    resblocks.Remove(g.blocks[i]);
                }
            }
        }

        Debug.Log(resblocks.ToString());

        //my_hashset.SetEquals(other);

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

    private List<HashSet<int>> CopyList(List<HashSet<int>> l)
    {
        List<HashSet<int>> res = new List<HashSet<int>>();
        foreach (HashSet<int> l2 in l)
        {
            res.Add(l2);
        }
        return res;
    }
}
