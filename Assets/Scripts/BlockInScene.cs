using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BlockInScene
{
    public string name;
    public Vector3 position;
    public Vector3 scale;
    public Quaternion rotation;

    public BlockInScene(string name, Vector3 position, Vector3 scale, Quaternion rotation)
    {
        this.name = name;
        this.position = position;
        this.scale = scale;
        this.rotation = rotation;
    }
}


