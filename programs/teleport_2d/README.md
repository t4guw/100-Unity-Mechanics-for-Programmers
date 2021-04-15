# Teleport Between Locations in 2D

## Description
This mechanic shows how to implement teleporting between two locations. This could be useful when there
are two locations on a map to teleport between.

## Implementation
This mechanic uses A and D to move along a platform, and W to use the portal. 
Ensure a BoxCollider 2D component has been attached to each teleport locaiton with the "Is Trigger" option checked.
Attach the following script to each teleport location:

    using UnityEngine;

    public class Teleport : MonoBehaviour
    {
        public int index;
        public SpriteRenderer destination;
        public SpriteRenderer player;
        private bool canTeleport = false;

        void OnTriggerEnter2D(Collider2D other) {
            canTeleport = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W) && canTeleport)
            {
                player.transform.position = destination.transform.position;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            canTeleport = false;
        }
    }

Drag and drop the destination to the "destination" field in the inspector, and the player
to the "player" field in the inspector.