using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Graph
{

    public int vertices;
    public List<int> vertexList;
    public List<LinkedList<int>> adj_list;
    public int[,] matrix;
    public List<Edge> edges;
    public List<LinkedList<int>> tree_adj_list;
    private int randomDelete;
    private List<int> randomIdx;
    private List<Edge> treeEdges;
    public List<Edge> listOfDeletedEdges;
    public List<HashSet<int>> blocks;


    public Graph(int v)
    {
        vertices = v;
        adj_list = new List<LinkedList<int>>();
        tree_adj_list = new List<LinkedList<int>>();
        vertexList = new List<int>();
        edges = new List<Edge>();
        treeEdges = new List<Edge>();
        listOfDeletedEdges = new List<Edge>();

        for (int i = 0; i < v; i++)
        {
            adj_list.Add(new LinkedList<int>());
            tree_adj_list.Add(new LinkedList<int>());
        }
        matrix = new int[v, v];
        for (int i = 0; i < v; i++)
        {
            vertexList.Add(i);
        }
        randomDelete = Random.Range(6, 9);
        randomIdx = new List<int>();
        blocks = new List<HashSet<int>>();
    }

    public void Kruskals_MST(List<Edge> edges, List<int> vertices)
    {
        //making set
        List<List<int>> listSet = new List<List<int>>();
        foreach (int vertex in vertices)
        {
            List<int> temp = new List<int>();
            temp.Add(vertex);
            listSet.Add(temp);
        }

        //sorting the edges order by weight ascending
        var sortedEdge = edges.OrderBy(x => x.weight).ToList();

        foreach (Edge edge in sortedEdge)
        {
            //adding edge to result if both vertices do not belong to same set
            //both vertices in same set means it can have cycles in tree
            bool success = true;
            int idx1 = -2;
            int idx2 = -1;
            bool found1 = false;
            bool found2 = false;
            for (int i = 0; i < listSet.Count; i++)
            {
                if (listSet[i].Contains(edge.vertexId1))
                {
                    idx1 = i;
                    found1 = true;
                }
                if (listSet[i].Contains(edge.vertexId2))
                {
                    idx2 = i;
                    found2 = true;
                }
                if (found1 && found2)
                {
                    if (idx1 == idx2)
                    {
                        success = false;
                    }
                    else
                    {
                        success = true;
                    }
                    break;
                }
            }

            if (success)
            {
                addEdge_for_tree(edge.vertexId1, edge.vertexId2);
                listSet[idx1].AddRange(listSet[idx2]);
                listSet[idx2].Clear();
            }
        }
    }

    void DFS_helper(int v, bool[] visited)
    {
        // current node is visited 
        visited[v] = true;

        LinkedList<int>.Enumerator iter = adj_list[v].GetEnumerator();
        while (iter.MoveNext())
        {
            int n = iter.Current;
            if (!visited[n])
                DFS_helper(n, visited);
        }
    }


    public void DFS(int v)
    {
        //initially none of the vertices are visited 
        bool[] visited = new bool[vertices];

        // call recursive DFS_helper function for DFS technique 
        DFS_helper(v, visited);
    }

    void DFS_helper_for_tree(int v, bool[] visited, int idx)
    {
        visited[v] = true;
        blocks[idx].Add(v);

        LinkedList<int>.Enumerator iter = tree_adj_list[v].GetEnumerator();
        while (iter.MoveNext())
        {
            int n = iter.Current;
            if (!visited[n])
                DFS_helper_for_tree(n, visited, idx);
        }
    }

    public void DFS_for_tree(int v, int idx)
    {
        bool[] visited = new bool[vertices];

        DFS_helper_for_tree(v, visited, idx);
    }

    public void addEdge(int v1, int v2, int w)
    {
        adj_list[v1].AddLast(v2);
        adj_list[v2].AddLast(v1);
        matrix[v1, v2] = w;
        matrix[v2, v1] = w;
        edges.Add(new Edge() { vertexId1 = v1, vertexId2 = v2, weight = w });
    }

    public void addEdge_for_tree(int v1, int v2)
    {
        tree_adj_list[v1].AddLast(v2);
        tree_adj_list[v2].AddLast(v1);
    }


    public void randomDeletion()
    {
        while(randomDelete > 0)
        {
            int temp = Random.Range(0, treeEdges.Count);
            if (!randomIdx.Contains(temp))
            {
                randomIdx.Add(temp);
                randomDelete--;
            }
        }
        for(int i = 0; i < randomIdx.Count; i++)
        {
            listOfDeletedEdges.Add(treeEdges[randomIdx[i]]);
            tree_adj_list[treeEdges[randomIdx[i]].vertexId1].Remove(treeEdges[randomIdx[i]].vertexId2);
            tree_adj_list[treeEdges[randomIdx[i]].vertexId2].Remove(treeEdges[randomIdx[i]].vertexId1);
        }
    }

    public void findTreeEdges()
    {
        for(int i = 0; i < tree_adj_list.Count; i++)
        {
            var currentNode = tree_adj_list[i].First;
            while (currentNode != null) {
                treeEdges.Add(new Edge() { vertexId1 = i, vertexId2 = currentNode.Value, weight = 0});
                currentNode = currentNode.Next;
            }
        }
    }


    public void addRandomWeigths()
    {
        var rand = new System.Random();
        var rtnlist = new List<int>();

        for (int i = 0; i < 50; i++)
            rtnlist.Add(rand.Next(1000));

        if (vertices == 16)
        {
            addEdge(0, 1, rtnlist[0]);
            addEdge(1, 2, rtnlist[1]);
            addEdge(2, 3, rtnlist[2]);
            addEdge(3, 4, rtnlist[3]);
            addEdge(4, 5, rtnlist[4]);
            addEdge(5, 6, rtnlist[5]);
            addEdge(6, 7, rtnlist[6]);
            addEdge(7, 8, rtnlist[7]);
            addEdge(8, 9, rtnlist[8]);
            addEdge(9, 10, rtnlist[9]);
            addEdge(10, 11, rtnlist[10]);
            addEdge(11, 12, rtnlist[11]);
            addEdge(12, 13, rtnlist[12]);
            addEdge(13, 14, rtnlist[13]);
            addEdge(14, 15, rtnlist[14]);
            addEdge(15, 2, rtnlist[15]);
            addEdge(3, 0, rtnlist[16]);
            addEdge(7, 4, rtnlist[17]);
            addEdge(11, 8, rtnlist[18]);
            addEdge(15, 12, rtnlist[19]);
        }
        else if (vertices == 36)
        {
            addEdge(0, 1, rtnlist[0]);
            addEdge(1, 2, rtnlist[1]);
            addEdge(2, 3, rtnlist[2]);
            addEdge(3, 0, rtnlist[3]);
            addEdge(3, 4, rtnlist[4]);
            addEdge(4, 5, rtnlist[5]);
            addEdge(5, 6, rtnlist[6]);
            addEdge(6, 7, rtnlist[7]);
            addEdge(4, 7, rtnlist[8]);
            addEdge(7, 8, rtnlist[9]);
            addEdge(8, 9, rtnlist[10]);
            addEdge(9, 10, rtnlist[11]);
            addEdge(10, 11, rtnlist[12]);
            addEdge(11, 12, rtnlist[13]);
            addEdge(11, 8, rtnlist[14]);
            addEdge(12, 13, rtnlist[15]);
            addEdge(13, 14, rtnlist[16]);
            addEdge(14, 15, rtnlist[17]);
            addEdge(15, 16, rtnlist[18]);
            addEdge(12, 15, rtnlist[19]);
            addEdge(16, 17, rtnlist[20]);
            addEdge(17, 18, rtnlist[21]);
            addEdge(18, 19, rtnlist[22]);
            addEdge(16, 19, rtnlist[23]);
            addEdge(19, 20, rtnlist[24]);
            addEdge(20, 21, rtnlist[25]);
            addEdge(20, 22, rtnlist[26]);
            addEdge(22, 23, rtnlist[27]);
            addEdge(21, 23, rtnlist[28]);
            addEdge(23, 24, rtnlist[29]);
            addEdge(24, 25, rtnlist[30]);
            addEdge(25, 26, rtnlist[31]);
            addEdge(27, 26, rtnlist[32]);
            addEdge(27, 28, rtnlist[33]);
            addEdge(27, 24, rtnlist[34]);
            addEdge(28, 29, rtnlist[35]);
            addEdge(29, 31, rtnlist[36]);
            addEdge(30, 31, rtnlist[37]);
            addEdge(30, 28, rtnlist[38]);
            addEdge(31, 32, rtnlist[39]);
            addEdge(32, 33, rtnlist[40]);
            addEdge(33, 34, rtnlist[41]);
            addEdge(34, 35, rtnlist[42]);
            addEdge(32, 35, rtnlist[43]);
            addEdge(9, 30, rtnlist[44]);
            addEdge(10, 22, rtnlist[45]);
            addEdge(6, 33, rtnlist[46]);
            addEdge(2, 13, rtnlist[47]);
        }
    }
}
