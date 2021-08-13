# Summon Ally

## Description
This mechanic will demonstrate how to allow the player to summon an ally with a simple key press. When the key is pressed, the ally will follow the player for 5 seconds.

## Implementation
There are several steps that need to be completed in the Unity Editor:
   1. Create a player object and an ally object.
   2. Attach the following SummonAlly script to the player.
   3. Create an empty object as a child of the player to be there "Ally Follow Location".
   4. Drag the corresponding objects into the variables of the SummonAlly script.

    using UnityEngine;

    public class SummonAlly : MonoBehaviour
    {
        public GameObject ally;
        public Transform allyFollowLoc;
        float timerStart;
        bool allyFollowing;

        void Start()
        {
            timerStart = Time.time - 5f;
            allyFollowing = false;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                allyFollowing = true;
                timerStart = Time.time;
            }
            if (allyFollowing)
            {
                if (ally.transform.position != allyFollowLoc.position)
                {
                    ally.transform.position = Vector3.MoveTowards(ally.transform.position, allyFollowLoc.position, .01f);
                }
                else
                {
                    ally.transform.parent = transform;
                }
            }

            if (Time.time - timerStart > 5)
            {
                allyFollowing = false;
                ally.transform.parent = null;
            }
        }
    }