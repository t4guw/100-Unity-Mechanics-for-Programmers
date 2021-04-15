using UnityEngine;

public class CoinBehavior : MonoBehaviour
{   
    void Update()
    {
        transform.Rotate(0,  0, 60f * Time.smoothDeltaTime);
    }
}
