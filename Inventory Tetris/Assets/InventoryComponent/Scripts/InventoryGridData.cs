
using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/Grid", order = 1)]
public class InventoryGridData : ScriptableObject
{
    public bool[,] shape;
}