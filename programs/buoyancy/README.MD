# Buoyancy
## Description
This mechanic shows how to implement water objects

## Implementation
1. This mechanic can luckily be done entirely within Unity by adding the Buoyancy Effector to the Game Object that is to be your water.
2. You can set the component to use Collider Masks which will allow you to set the water to only affect certain Layers.
3. The Density determines the viscosity of the water (think water vs honey).
4. Surface level determines where the "Surface" of the water is which defaults to the middle of the object. Make sure to change this.
5. You can also give the Water a flow direction with Flow Angle, Magnitute, and Variation.