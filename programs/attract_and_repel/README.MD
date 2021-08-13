# Attract and Repel
## Description
This mechanic shows how to pull and push forces like orbiting bodies.

## Implementation
1. This mechanic can luckily be done entirely within Unity by using the Point Effector Component
2. The Point Effector Component requires the use of a Collider 2D which in most cases you will want to be separate from the Collider of the object you want to give the attract/repel force to,
3. Once you have your Collider (I suggest having an empty GameObject as a child to the object that you want to do this with and give that the Collider and Point Effector) Set the collider to the size you want the force to have an effect to, the pull/push force will only act upon objects within the collider.
4. Within the Point Effector 2D, the Force Magnitude determines the direction and how strong the force is (negative is towards the object and positive is away)
5. The Force Mode determines if the Force is 100% regardless of where the affected object is within the collider or if it acts more like gravity where the closer to the object the stronger the attraction. (For gravity like force use Inverse Squared)
6. The Distance Scale determines the magnitude of the force based on the distance to the other object.
7. Lastly like the other Effectors you can use a Collider Mask to decide who is effected by the forces.
8. One important thing to note, due to this Effector's special need of it's own Collider, this can cause issues with other usually reliable methods of game mechanics.
Such as, relying on the OnMouseDown method which is called when the Mouse clicks within an object's collider space, will be called by any Collider that is within that game object or it's childeren.