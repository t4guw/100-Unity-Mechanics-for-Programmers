# Drag and Drop to Nearest Corner

## Description
This mechanic shows how to drag and drop to the nearest corner of a square object.
This mechanic could be useful when developing a game similar to a "dress-up" game, and when 
placing clothing items on a character.

## Implementation
This implemenation builds on the previous mechanic "Drag and Drop UI." There are
several steps that need to be completed in the Unity Editor.
1. Ensure there is a GameObject that will act as the parent that will determine which corner to snap to.
2. Create an empty game object for each corner, and anchor them to each corner.
3. Ensure each corner object is invisible/transparent.
4. Attach the following code to each item slot (4 of them).

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
5. Attach the following code to each draggable item.

        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using UnityEngine.EventSystems;
        public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
        {
            private RectTransform rectTransform;
            [SerializeField] private Canvas canvas;
            private CanvasGroup canvasGroup;
            public Transform originalParent;

            private void Awake()
            {
                rectTransform = GetComponent<RectTransform>();
                canvasGroup = GetComponent<CanvasGroup>();
            }

            public void OnBeginDrag(PointerEventData eventData)
            {
                canvasGroup.blocksRaycasts = false;
                canvasGroup.alpha = 0.5f;
                if (originalParent != null)
                {
                    transform.parent = originalParent;
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

            public void OnPointerDown(PointerEventData eventData)
            {
                Debug.Log("PointerDown");
            }

        }

This mechanic can be expanded to include more "slots" or corners by creating more transparent objects and anchoring them to different spots on the visible slot.