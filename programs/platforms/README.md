# Platforms

## Description
This mechanic shows how create platforms that allow one-way movement (Such as jumping up from below and landing on top of the platform)

## Implementation
1. This is another mechanic that can be done entirely within Unity by adding the Platform Effector 2D to the platform you want to use.
2. Make sure your platform has a collider (something other than a box collider may cause some issues you'll need to account for when adjusting the Effector settings)
3. Check the "Used by Effector" box in your Collider and add the Platform Effector 2D. If you just want the player to be able to jump up from below and land then you're already done.
Like the other effectors you can use a Collider Mask so that the Platform Effector only applies to certain objects trying to pass through the platform.
Disabling Use One Way just makes the platform act like a regular game object with a collider (which could be potentially used as an activatable one-way door)
The Use One Way Grouping: "Ensures that all contacts disabled by the one-way behaviour act on all colliders. This is useful when multiple colliders are used on the object passing through the platform and they all need to act together as a group." - Unity Documentation
The Surface Arc coupled with the Rotational Offset can indicate the direction and area the "surface" of the platform covers, aka if you make a long platform but the surface arc only covers the middle part of it, the player will fall through if they are outside of it.
Side Friction enables/disables friction when touching the sides of the platform as well as Side Bounce while Side Arc helps determine the sides of the platform.

