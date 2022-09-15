using System.Collections.Generic;

public class Node
{
    int id;
    List<Node> neighbors;
    List<Edge> edges;
    public Node(int id)
    {
        this.id = id;
        neighbors = new List<Node>();
        edges = new List<Edge>();
    }
}
