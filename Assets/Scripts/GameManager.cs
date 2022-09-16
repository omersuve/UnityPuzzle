using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int boardSize;

    private GameObject selectedPiece;
    private GameObject selectedParentBlock;
    private bool isGameOver = false;
    private Graph g;
    private List<HashSet<int>> resblocks;

    List<GameObject> mergedBlocks;

    void Start()
    {
        g = new Graph(boardSize);

        g.addRandomWeigths();

        g.Kruskals_MST(g.edges, g.vertexList);

        g.findTreeEdges();

        g.randomDeletion();

        int k = 0;
        for (int i = 0; i < g.listOfDeletedEdges.Count; i++)
        {
            g.blocks.Add(new HashSet<int>());
            g.DFS_for_tree(g.listOfDeletedEdges[i].vertexId1, k);
            g.blocks.Add(new HashSet<int>());
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

        mergedBlocks = new List<GameObject>();

        for (int i = 0; i < resblocks.Count; i++)
        {
            mergedBlocks.Add(new GameObject("piece"+i));
            foreach (var v in resblocks[i])
            {
                GameObject.Find(v.ToString()).transform.SetParent(GameObject.Find("piece"+i).transform);
            }
            GameObject block = GameObject.Find("piece" + i);
            block.tag = i.ToString();
            block.AddComponent<Block>();
            SpriteRenderer[] childs = block.GetComponentsInChildren<SpriteRenderer>();
            Color c = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            foreach (SpriteRenderer child in childs)
            {
                child.material.color = c;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log(hit);
            try
            {
                if (hit.transform.CompareTag("Piece"))
                {
                    Debug.Log("girdi");
                    selectedPiece = hit.transform.gameObject;
                    Transform temp = selectedPiece.transform.parent;
                    selectedParentBlock = GameObject.FindGameObjectWithTag(temp.tag);
                }
            }
            catch (NullReferenceException ex)
            {
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
