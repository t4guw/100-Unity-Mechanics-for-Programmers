# Camera Shake

## Description
This mechanic shows how to implement camera shake. This could be used to emphasize an effect during the game, such as an explosion, earthquake, or impact.

## Implementation
First, create an Empty GameObject as the parent of the Main Camera. Ensure it has the same positioning as the Main Camera. This will serve as the anchor for the camera location, and is where the camera will return to after shaking.  

The camera shake can be activated in a variety of ways, such as during an explosion, on Key press, or on button press. However, in any of these implementations, you will use a Coroutine. See more about Coroutines [here](https://docs.unity3d.com/Manual/Coroutines.html). To call a Coroutine, use the `StartCoroutine()` function.  

There are many ways to implement camera shake. There are various ways to code it, as well as various Assets on the Unity Asset Store. Below is a simple implementation, where camera shake will be activated with the press of a button.
### 
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraShake : MonoBehaviour
    {
        public void CallShake()
        {
            StartCoroutine(Shake(0.4f,0.7f));
        }

        public IEnumerator Shake (float duration, float magnitude)
        {
            Vector3 originalPos = transform.localPosition;

            float elapsed = 0.0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, y, originalPos.z);

                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPos;
        }
    }