using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public Camera cam;
    Vector2 mousePos;
    public Rigidbody2D rb2d;
    public float rotateSpeed = 50f;
    public bool instant = false;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Vector2 lookDirection = mousePos - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        if (instant)
        {
            rb2d.rotation = angle;

        }
        else
        {
            Quaternion qTo = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, rotateSpeed * Time.deltaTime);
        }
    }
}
