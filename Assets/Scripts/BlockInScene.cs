using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BlockInScene
{
    public string name;
    public Vector3 position;
    public List<int> vertices;
    public Color color;

    public BlockInScene(string name, Vector3 position, List<int> vertices, Color color)
    {
        this.name = name;
        this.position = position;
        this.vertices = vertices;
        this.color = color;
    }
}


