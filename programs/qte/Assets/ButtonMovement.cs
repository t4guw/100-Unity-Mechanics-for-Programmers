using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= 8f * Time.deltaTime;
        transform.position = pos;
    }
}
