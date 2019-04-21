using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public InventoryItemData data;
    private List<GameObject> slots;

    public static event Action<InventoryItem> ItemDragBegun;
    public static event Action ItemDragEnded;

    private void Awake()
    {

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        OnItemDragBegun();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnItemDragEnded();
    }

    protected virtual void OnItemDragBegun()
    {
        if (ItemDragBegun != null)
        {
            ItemDragBegun(this);
        }
    }

    protected virtual void OnItemDragEnded()
    {
        if (ItemDragEnded != null)
        {
            ItemDragEnded();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
