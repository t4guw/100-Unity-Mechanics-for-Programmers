# Drag and Drop UI

## Description
This mechanic will show how to implement a UI feature that allows for dragging and dropping items using the mouse. The selected object will follow the mouse cursor and become slightly transparent when dragged. When dropped into or near an appropriate slot, the object will snap into position.

## Implementation
There are two pieces of code and several steps that need to be done inside the editor
- Ensure a UI canvas has been created
- In the UI, create one object with an "Image" component that will represent the dragged object, and another that will represent the slot for the item. Ensure that the objects in the UI hierarchy are in the correct order to ensure that the item will be rendered on top of the slot rather than behind it. The item slot should be first, and the item second.
- Add a "Canvas Group" component to the item
- The below script will be attached to the item:

        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using UnityEngine.EventSystems;

        public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
        {
            private RectTransform rectTransform;
            [SerializeField] private Canvas canvas;
            private CanvasGroup canvasGroup;

            private void Awake() {
                rectTransform = GetComponent<RectTransform>();    
                canvasGroup = GetComponent<CanvasGroup>();
            }

            public void OnBeginDrag(PointerEventData eventData)
            {
                canvasGroup.blocksRaycasts = false;
                canvasGroup.alpha = 0.5f;
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
                Debug.Log("PointerDown");
            }

        }
- The below script will be added to the item slot:

        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using UnityEngine.EventSystems;

        public class ItemSlot : MonoBehaviour, IDropHandler
        {
            public void OnDrop(PointerEventData eventData)
            {
                if (eventData.pointerDrag != null) {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                }
            }
        }


