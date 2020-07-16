using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public LineRenderer lineRenderer;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.up, transform.up);

        if (hitInfo)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        } else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.up * 100);
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }
}
