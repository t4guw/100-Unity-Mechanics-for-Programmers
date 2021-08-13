# Wind Force
## Description
This mechanic will show how to implement Wind Force or Areas of Force

## Implementation
1. This is another mechanic that can luckily be entirely done within Unity with the Area Effector 2D Component.
2. To do this, create a Empty Object in the Hierarchy, in this Object add a Collider 2D and an Area Effector 2D component.
3. Adjust the Collider to match what you want as it doesn't encapsulate an actual object, then check "Used By Effector" and "Is Trigger"
4. For Area Effector 2D you can check the "Use Collider Mask" to have this object only effect objects in a specific layer.
Otherwise you can set the angle of force (O goes Positive on the X Axis), the rotation of the object does effect the direction as well which you can turn off by checking "Use Global Angle". Magnitude self explainatory.
