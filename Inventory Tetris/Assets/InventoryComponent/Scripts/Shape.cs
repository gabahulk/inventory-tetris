using UnityEngine;
using System.Collections;

[System.Serializable]
public class Shape
{
    static int width = 3;
    static int height = 3;

    [System.Serializable]
    public class rowData
    {
        public bool[] row = new bool[height];
    }

    public rowData[] rows = new rowData[width];
}
