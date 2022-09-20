using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BlockContainer
{
    public List<BlockInScene> Content = new List<BlockInScene>();

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}
