using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private GameObject itemSlot;
    public int index = -1;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();    
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.5f;
        if (index != -1) {
            itemSlot = rectTransform.parent.gameObject;
            ItemSlot slot = itemSlot.GetComponent<ItemSlot>();
            slot.filled[index] = false;
            index = -1;
        } 
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        
    }

    public void OnPointerDown(PointerEventData eventData) {
        
    }

}
