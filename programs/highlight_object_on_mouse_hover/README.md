# Highlight Object On Mouse Hover
## Description
This mechanic shows how to implement highlighting objects when the mouse hovers over them.

## Implementation
1. This implementation relies on separate images/sprites that are highlight versions of the images you want to highlight. Unfortunately unlike 3D Unity, a shader cannot be applied to achieve this affect and so this is one of the alternatives.
2. You can create a simple highlighted versions of your images in Photoshop or Paint.Net (Free) by changing the lightness to max. The drawback this solution has, is on more complex objects, the highlight isn't even, this works better on simple shaped objects like squares or circles.
3. Create a new script called "Highlight"
4. Add "using UnityEngine.UI;" to the top
5. In variables create a public GameObject highlight, this object will be set active and inactive on mouse hover.
6. In our case we're also using a panel to further highlight the object so create 3 additional variables:
private Image img;
private Color original = new Color(0.59f, 0.41f, 0.25f, 1.0f);
private Color dark = new Color(0.55f, 0.37f, 0.21f, 1.0f);
In this case the color is a brown and darker brown, you can change these colors to anything you want.
7. Within the void Start() method assign the img variable to the panel's Image component: img = gameObject.GetComponent<Image>();
8. Now create two methods, public void OnMouseOver() and public void OnMouseExit()
9. Within OnMouseOver() set highlight to active: "highlight.SetActive(true);" and set the panel's color to dark: "img.color = dark;"
10. Now within OnMouseExit() do the opposite; set highlight to inactive: highlight.SetActive(false); and return the panel to it's original color: "img.color = original;"
11. Back within Unity, you need to add a Collider to the object you want to highlight as this collider will trigger the OnMouseOver and OnMouseExit methods. Depending on your object you can use a Box Collider, Capsule Collider, Circle Collider, or a Polygon Collider, and you can adjust these to increase/decrease the area that the mouse has to go over to highlight the object.
12. Now add the Highlight script to your object (In this case we added it to the panel holding the object) and assign the highlight game object to the script.
13. For your highlight to actually show, you'll need to mess around with the size of the highlight, making sure it's directly behind the original object, but now when you hover over your object, the highlight object will appear and disappear when the move leaves.