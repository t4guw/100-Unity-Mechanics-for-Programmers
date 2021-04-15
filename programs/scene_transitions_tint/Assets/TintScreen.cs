using System.Collections;
using UnityEngine;

public class TintScreen : MonoBehaviour
{
    public CanvasGroup tint;
    public float tintTime = 0.2f;
    public float opacity = 0.5f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Tint();
        }
    }

    public void Tint()
    {
        StartCoroutine(ShowColor(tint));
    }

    IEnumerator ShowColor(CanvasGroup tint)
    {
        tint.alpha = opacity;

        yield return new WaitForSeconds(tintTime);

        tint.alpha = 0;

    }
}
