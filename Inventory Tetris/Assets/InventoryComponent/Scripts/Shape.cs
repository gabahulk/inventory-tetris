using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Shape
{
    [Range(1,10)]
    public int Width = 3;
    [Range(1,10)]
    public int Height = 3;
    public List<bool> Slots = new List<bool>();
}
