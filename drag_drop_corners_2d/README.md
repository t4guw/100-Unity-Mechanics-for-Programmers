# Drag and Drop Snap to Corners

## Description
This mechanic builds upon the "Drag and Drop" mechanic. There are now multiple draggable objects with
one slot. Instead of snapping to the center of the slot, the objects will snap to the corners of the slot.
The object will always find the first open corner (starting from bottom left and going clockwise) and snap
to that corner. For example, if the first 3 corners (bottom left, top left, top right) are filled, then
the first corner (bottom left is removed), the next object will snap to the first corner, rather than moving
to the fourth corner.

## Impelmentation
This first snippet of code is attached to each draggable object.

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

The second snippet of code is attached to the item slot.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        RectTransform rt;
        public Vector3[] v = new Vector3[4];
        public bool[] filled = new bool[4];
        private DragDrop dragDrop;
        void Start()
        {
            rt = GetComponent<RectTransform>();
        }
        public void OnDrop(PointerEventData eventData)
        {
            rt.GetLocalCorners(v);
            eventData.pointerDrag.transform.SetParent(rt);
            dragDrop = eventData.pointerDrag.gameObject.GetComponent<DragDrop>();
            if (eventData.pointerDrag != null) {
                Vector2 curr;
                for (int i = 0; i < 4; i++) {
                    if (filled[i] == false) {
                        curr = v[i];
                        filled[i] = true;
                        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = curr;
                        dragDrop.index = i;
                        break;
                    }
                    
                }
            }
                
        }
    }
