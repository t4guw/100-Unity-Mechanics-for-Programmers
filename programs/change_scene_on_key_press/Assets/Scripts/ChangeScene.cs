using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// For Scene Management
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private KeyCode navigate = KeyCode.N;
    private KeyCode scene1 = KeyCode.Alpha1;
    private KeyCode scene2 = KeyCode.Alpha2;
    private KeyCode scene3 = KeyCode.Alpha3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(navigate))
            {
                if (SceneManager.GetActiveScene().buildIndex >= 2)
                {
                    SceneManager.LoadScene(0);
                }
                else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (Input.GetKey(scene1))
            {
                SceneManager.LoadScene(0);
            }
            else if (Input.GetKey(scene2))
            {
                SceneManager.LoadScene(1);
            }
            else if (Input.GetKey(scene3))
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
