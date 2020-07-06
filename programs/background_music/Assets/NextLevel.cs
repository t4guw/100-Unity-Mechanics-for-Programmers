using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int index;
    void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.W)) {
            SceneManager.LoadScene(index);
        }
    }
}
