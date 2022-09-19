using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;
using Text = UnityEngine.UI.Text;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int boardSize;

    [SerializeField] private GameObject board;
    [SerializeField] private GameObject triangles;

    [SerializeField] private GameObject p0;
    [SerializeField] private GameObject p1;
    [SerializeField] private GameObject p2;
    [SerializeField] private GameObject p3;
    [SerializeField] private GameObject p4;
    [SerializeField] private GameObject p5;
    [SerializeField] private GameObject p6;
    [SerializeField] private GameObject p7;
    [SerializeField] private GameObject p8;
    [SerializeField] private GameObject p9;
    [SerializeField] private GameObject p10;
    [SerializeField] private GameObject p11;
    [SerializeField] private GameObject p12;
    [SerializeField] private GameObject p13;
    [SerializeField] private GameObject p14;
    [SerializeField] private GameObject p15;
    [SerializeField] private GameObject p16;
    [SerializeField] private GameObject p17;
    [SerializeField] private GameObject p18;
    [SerializeField] private GameObject p19;
    [SerializeField] private GameObject p20;
    [SerializeField] private GameObject p21;
    [SerializeField] private GameObject p22;
    [SerializeField] private GameObject p23;
    [SerializeField] private GameObject p24;
    [SerializeField] private GameObject p25;
    [SerializeField] private GameObject p26;
    [SerializeField] private GameObject p27;
    [SerializeField] private GameObject p28;
    [SerializeField] private GameObject p29;
    [SerializeField] private GameObject p30;
    [SerializeField] private GameObject p31;
    [SerializeField] private GameObject p32;
    [SerializeField] private GameObject p33;
    [SerializeField] private GameObject p34;
    [SerializeField] private GameObject p35;


    private GameObject selectedPiece;
    private GameObject selectedParentBlock;
    private bool isGameOver = false;
    private Graph g;
    private List<HashSet<int>> resblocks;
    private List<GameObject> blocks;
    public Text endText;
    Vector2 offset = Vector2.zero;
    Dictionary<Vector2, bool> truePositions;

    List<GameObject> mergedBlocks;

    void Start()
    {
        endText.enabled = false;

        truePositions = new Dictionary<Vector2, bool>();

        if(SceneManager.GetActiveScene().buildIndex == 1)
            addTruePositionsHard();
        else
            addTruePositionsEasy();

        //foreach (Vector2 i in truePositions.Keys)
        //    Debug.Log(i);

        blocks = new List<GameObject>();

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
            blocks.Add(block);
            
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
        //foreach (Vector2 key in truePositions.Keys)
            //Debug.Log(truePositions[key].ToString());

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform == null)
                return;
            if (hit.transform.CompareTag("Piece"))
            {
                selectedPiece = hit.transform.gameObject;
                Transform temp = selectedPiece.transform.parent;
                selectedParentBlock = GameObject.FindGameObjectWithTag(temp.tag);
                selectedParentBlock.GetComponent<Block>().selected = true;
                offset = (Vector2)(hit.transform.position - selectedParentBlock.transform.position);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (selectedParentBlock == null)
                return;
            selectedParentBlock.GetComponent<Block>().selected = false;
            selectedPiece = null;
            selectedParentBlock = null;
        }

        if(selectedParentBlock != null)
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedParentBlock.transform.position = new Vector3(mousePoint.x, mousePoint.y, 0) - new Vector3(offset.x, offset.y, 0);
        }

        changePositions();

        isGameOver = CheckGameOver();
        if (isGameOver)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
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

    private void changePositions()
    {
        foreach (GameObject block in blocks)
        {
            //Debug.Log("Block name: " + block.name);
            foreach (Vector3 pos in block.GetComponent<Block>().locations)
            {
                //Debug.Log((Vector2)pos);
                if (truePositions.ContainsKey(new Vector2((float)Math.Round(pos.x, 1), (float)Math.Round(pos.y, 1))))
                {
                    truePositions[pos] = true;
                    //Debug.Log("changed");
                }
            }
        }
    }

    private bool CheckGameOver()
    {
        foreach (Vector3 loc in truePositions.Keys)
        {
            if (truePositions[loc] == false)
                return false;
        }
        return true;
    }

    private void addTruePositionsEasy()
    {
        truePositions.Add((Vector2)p0.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p1.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p2.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p3.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p4.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p5.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p6.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p7.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p8.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p9.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p10.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p11.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p12.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p13.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p14.transform.localPosition + new Vector2(-4, 0), false);
        truePositions.Add((Vector2)p15.transform.localPosition + new Vector2(-4, 0), false);
    }

    private void addTruePositionsHard()
    {
        truePositions.Add(new Vector2((float)Math.Round(p0.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p0.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p1.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p1.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p2.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p2.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p3.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p3.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p4.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p4.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p5.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p5.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p6.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p6.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p7.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p7.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p8.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p8.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p9.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p9.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p10.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p10.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p11.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p11.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p12.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p12.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p13.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p13.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p14.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p14.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p15.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p15.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p16.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p16.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p17.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p17.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p18.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p18.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p19.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p19.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p20.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p20.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p21.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p21.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p22.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p22.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p23.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p23.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p24.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p24.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p25.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p25.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p26.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p26.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p27.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p27.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p28.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p28.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p29.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p29.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p30.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p30.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p31.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p31.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p32.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p32.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p33.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p33.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p34.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p34.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
        truePositions.Add(new Vector2((float)Math.Round(p35.transform.localPosition.x * 2 / 3 - 5.18, 1), (float)Math.Round(p35.transform.localPosition.y * 2 / 3 - 1.33, 1)), false);
    }
}
