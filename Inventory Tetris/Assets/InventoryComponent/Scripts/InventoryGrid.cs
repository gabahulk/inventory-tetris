using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    public GameObject slotPrefab;
    public float slotSpacing = 0.0f;

    private float slotSize;

    public Shape gridShape;

    private void Start()
    {
        slotSize = slotPrefab.GetComponent<RectTransform>().rect.width;
        InstanciateShape(gridShape);
    }

    private int GetSlotIndexByBidimensionalCoordinates(Shape shape, int x, int y)
    {
        return shape.Width * y + x;
    }

    private void CreateSlot(Shape shape, int x, int y)
    {
        var inventoryWidth = slotSize * shape.Width;
        var inventoryHeight = slotSize * shape.Height;
        int index = GetSlotIndexByBidimensionalCoordinates(shape, x, y);
        if (shape.Slots[index])
        {
            GameObject slotInstance = Instantiate(slotPrefab);
            slotInstance.transform.SetParent(transform);
            Vector3 slotPosition = new Vector3(x * slotSize - inventoryWidth/2, y * slotSize - inventoryHeight/2);
            slotInstance.transform.localPosition = slotPosition;
        }
    }

    private void InstanciateShape(Shape shape)
    {
        for (int i = 0; i < shape.Width; i++)
        {
            for (int j = 0; j < shape.Height; j++)
            {
                CreateSlot(shape, i,j);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
        }
    }
}
