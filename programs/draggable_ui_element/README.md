# Draggable UI Elements
## Description
This mechanic shows how create ui elements that are dragable by the player.

## Implementation
1. This implementation can potentially work with any game object.
2. Create a new C# Script called "Draggable"
3. Add "using UnityEngine.EventSystems;" to the resources.
4. After "MonoBehavior" add ", IDragHandler, IPointerDownHandler" (This will be flagged as an error until we finish)
5. For variables write "[SerializeField] private RectTransform dragRectTransform;"
6. Create a new method:
public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta;
    }
This alone implements the draggable part of the script which updates the GameObject's anchored position in the game to where the mouse drags it to.
The OnDrag method paired with the IDragHandler, makes it so this method gets called whenever the user tries to drag the mouse.
7. Create a new method: 
public void OnPointerDown(PointerEventData eventData)
    {
        dragRectTransform.SetAsLastSibling();
    }
This makes it so the current object being dragged gets brought up to the front of the window.
8. Assign this script to any game object you want to drag and make sure you assign the dragRectTransform to that object.