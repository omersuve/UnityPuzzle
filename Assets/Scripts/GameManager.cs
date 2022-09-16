using System;
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
    private GameObject selectedParentBlock;
    public int Score;
    private Graph g;
    private List<Edge> resultedListEdges;
    private List<HashSet<int>> resblocks;

    List<GameObject> mergedBlocks;

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

        Debug.Log("***************");

        mergedBlocks = new List<GameObject>();

        for (int i = 0; i < resblocks.Count; i++)
        {
            mergedBlocks.Add(new GameObject("piece"+i));
            foreach (var v in resblocks[i])
            {
                Debug.Log(v);
                GameObject.Find(v.ToString()).transform.SetParent(GameObject.Find("piece"+i).transform);
            }
            GameObject block = GameObject.Find("piece" + i);
            block.tag = i.ToString();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log(hit);
            if (hit.transform.CompareTag("Piece"))
            {
                Debug.Log("girdi");
                selectedPiece = hit.transform.gameObject;
                Transform temp = selectedPiece.transform.parent;
                selectedParentBlock = GameObject.FindGameObjectWithTag(temp.tag);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedPiece = null;
            selectedParentBlock = null;
        }

        if(selectedParentBlock != null)
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedParentBlock.transform.position = new Vector3(mousePoint.x, mousePoint.y, 0);
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
