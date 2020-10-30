# Background Music

## Description
This mechanic will show how to implement background music.

## Implementation
There are several tasks that need to be done in the Unity editor. 
1. The first is ensuring the scenes have "Audio Listener" components attached to the main camera. 
2. Next, create an empty GameObject, and attach an "Audio Source" component to the object.
3. Drag and drop your audio clip to the "AudioClip" field in the Audio Source component. You can check the loop option if you want the audio to loop, control the volume, and other effects from the inspector.

There are two approaches to implement background music. 
- The first implementation involves having the background music stop upon loading a new screen. This would be used if you, for instance, want the main menu to have its own background music, and the first level having different music.

- The second implementation involves having the background music continue playing upon switching scenes. This would be used if you, for instance, want the same background music to continue playing once leaving the main menu. This involves attaching the following script to the newly created GameObject in order to prevent the Background Music object from destroying (stopping) itself upon loading a new scene.

        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

        public class ContinueAudio : MonoBehaviour
        {
            static ContinueAudio instance = null;
            private void Awake()
            {
                if (instance != null)
                {
                    Destroy(gameObject);
                }
                else
                {
                    instance = this;
                    GameObject.DontDestroyOnLoad(gameObject);
                }
            }
        }
