using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragDrop currSquare = eventData.pointerDrag.GetComponent<DragDrop>();
            currSquare.originalParent = currSquare.transform.parent;
            currSquare.transform.parent = transform; 
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Debug.Log(GetComponent<RectTransform>().anchoredPosition);
        }
    }
}