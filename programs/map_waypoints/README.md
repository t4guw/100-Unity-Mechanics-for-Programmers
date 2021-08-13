# Map Waypoints

## Description
This mechanic shows how to implement a waypoint system for a map.

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create a canvas with 2 UI images, one being the map, and the other the waypoint marker.
   2. Add Box Collider 2D to both map and waypoint.
   3. Make the waypoint a prefab and remove it from the hierarchy.
   4. Create an empty gameobject to be the 'Game Manager' and attach the WaypointScript to it.
   5. Drag the gameobjects to the corresponding global variables in the WaypointScript.