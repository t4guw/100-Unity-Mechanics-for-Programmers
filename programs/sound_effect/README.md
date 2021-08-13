# Sound Effect

## Description
This mechanic demonstrates applying a sound effect to an action. In this case we're reusing the "Ability Cooldown" Code that fires projectiles with the help of Unity Playground.

## Implementation
1. Make sure to add the Audio Source component to the object that will produce the sound and attach the sound effect to it.
2. These instructions should be done within the C# Script that does your action, otherwise you can create a new script that will play a sound effect on button press.
3. Within the script, add "[RequireComponent(typeof(AudioSource))]" to the top.
4. Within the class add public AudioClip soundEffect; and AudioSource audioSource; also add public KeyCode input; if you have no action.
5. Within the void Start() method (create one if you don't have one) add "audioSource = GetComponent<AudioSource>();"
6. Within the void Update() method (this is if you do not already have an action you want to add the sound effect to) add "if (Input.GetKeyDown(input))"
7. Otherwise, within your action (or in the if statement) write "audioSource.PlayOneShot(soundEffect, 0.7F);"
8. In Unity attach the sound effect to the component for the "soundEffect" object and you should be set.