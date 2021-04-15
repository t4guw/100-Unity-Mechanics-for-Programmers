using UnityEngine;

public class BlastBehavior : MonoBehaviour
{
    float blastRadiusSize = 5;
    Vector3 blastIncrease = new Vector3(0.005f, 0.005f, 0f);

    void Update()
    {
        if (this.transform.localScale.x < blastRadiusSize)
        {
            this.transform.localScale += blastIncrease;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
