# Map Waypoints

## Description
This mechanic shows how to implement a waypoint system for a map.

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create a canvas with 2 UI images, one being the map, and the other the waypoint marker.
   2. Set the waypoint marker as the child of the map.
   3. Add Box Collider 2D to the map and set the size to fill the map.
   4. Create an empty gameobject to be the 'Game Manager' and attach the WaypointScript to it.
   5. Drag the gameobjects to the corresponding global variables in the WaypointScript.