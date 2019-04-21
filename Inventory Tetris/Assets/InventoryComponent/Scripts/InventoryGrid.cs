using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class InventoryGrid : MonoBehaviour
{
    public GameObject slotPrefab;
    public float slotSpacing = 0.0f;

    public Shape gridShape;
    public List<GameObject> slots;

    private float slotSize;

    private RectTransform rect;
    InventoryItem currentItem;

    private void OnEnable()
    {
        InventoryItem.ItemDragBegun += SetCurrentItem;
        InventoryItem.ItemDragEnded += RemoveCurrentItem;
    }

    private void OnDisable()
    {
        InventoryItem.ItemDragBegun -= SetCurrentItem;
        InventoryItem.ItemDragEnded -= RemoveCurrentItem;
    }

    private void Start()
    {
        slots = new List<GameObject>();
        slotSize = slotPrefab.GetComponent<RectTransform>().rect.width;
        rect = this.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(slotSize * gridShape.Width, slotSize * gridShape.Height);
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
        var initialX = -inventoryWidth/2 + slotSize/2;
        var initialY = -inventoryHeight/2 + slotSize / 2;
        int index = GetSlotIndexByBidimensionalCoordinates(shape, x, y);
        if (shape.Slots[index])
        {
            GameObject slotInstance = Instantiate(slotPrefab);
            slots.Add(slotInstance);
            slotInstance.transform.SetParent(transform);
            Vector3 slotPosition = new Vector3(initialX + x * slotSize,initialY + y * slotSize);
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

    private void SetCurrentItem(InventoryItem item)
    {
        print("Item drag started!");
        currentItem = item;
    }

    private void RemoveCurrentItem()
    {
        print("Item drag ended!");
        currentItem = null;
    }

    private void Update()
    {
        if (currentItem)
        {
        }
    }
}
