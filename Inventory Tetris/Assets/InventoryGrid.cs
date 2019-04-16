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

    private void Start()
    {
        slotSize = slotPrefab.GetComponent<Image>().sprite.rect.height;

        for (int i = 1; i <= size; i++)
        {
            CreateDimension(i);
        }
    }

    private GameObject CreateSlot(int x, int y)
    {
        GameObject slotInstance = Instantiate(slotPrefab);
        slotInstance.transform.SetParent(transform);
        Vector3 slotPosition = new Vector3(x * slotSize/2, y * slotSize / 2);
        slotInstance.transform.position = this.transform.position + slotPosition;
        return slotInstance;
    }

    private void CreateDimension(int dimension)
    {
        int maxIndex = dimension - 1;

        for (int i = 0; i < dimension; i++)
        {
            CreateSlot(i, maxIndex);
            CreateSlot(maxIndex, i);
        }

        CreateSlot(maxIndex, maxIndex);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            size++;
            CreateDimension(size);
        }
    }
}
