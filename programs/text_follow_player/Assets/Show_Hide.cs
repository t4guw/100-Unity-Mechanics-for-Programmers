using UnityEngine;
using UnityEngine.UI;

public class Show_Hide : MonoBehaviour
{
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            this.GetComponent<Image>().enabled = !this.GetComponent<Image>().enabled;
        }
    }
}
