using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image image;
    public Item item;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Transform parentBeforeDrag;
    private void Start()
    {
        InitialiseItem(item);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }
    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;

    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;   
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true; 
    } 
}
