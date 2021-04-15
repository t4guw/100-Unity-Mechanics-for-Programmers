using UnityEngine;

public class Speed_Direction : MonoBehaviour {
    public float speed;
    public float rotateSpeed;
    private Rigidbody2D rb2d;

    void Start () {
      rb2d = GetComponent<Rigidbody2D> ();
    }
	

    void Update () {
        // Change Speed
        if (Input.GetKey(KeyCode.W)) {
            speed += 0.1f;
        } else if (Input.GetKey(KeyCode.S)) {
            if (speed - 2 < 0 ) {
                speed = 0f;
            } else {
                speed -= 0.1f;
            }
        }

        // Change direction
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0,0,rotateSpeed);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0,0,-1 * rotateSpeed);
        }
        rb2d.velocity = transform.up * speed;
    }
}