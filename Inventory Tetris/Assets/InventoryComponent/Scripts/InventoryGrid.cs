using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    public GameObject slotPrefab;
    public int size = 3;
    public float slotSize;
    public float slotSpacing = 0.0f;

    public Shape shape;

    private void Start()
    {
        slotSize = slotPrefab.GetComponent<Image>().sprite.rect.height;
        InstanciateShape();
    }

    private void CreateSlot(int x, int y)
    {
        if (shape.rows[x].row[y])
        {
            GameObject slotInstance = Instantiate(slotPrefab);
            slotInstance.transform.SetParent(transform);
            Vector3 slotPosition = new Vector3(x * slotSize/2, y * slotSize / 2);
            slotInstance.transform.position = this.transform.position + slotPosition;
        }
    }

    private void InstanciateShape()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                CreateSlot(i,j);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            size++;
        }
    }
}
