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
