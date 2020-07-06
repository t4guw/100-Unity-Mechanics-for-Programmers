using UnityEngine;

public class MovePlayer : MonoBehaviour {
    [SerializeField]private float acceleration = 10f;
    private Rigidbody2D rb2d;

    public Vector2 movement;

    void Start () {
      rb2d = GetComponent<Rigidbody2D> ();
    }
	

    void Update () {
        if (Input.GetKey(KeyCode.Space)) {
            moveCharacter(transform.right);
        } 
    }

    void moveCharacter(Vector3 direction) {
        rb2d.AddForce(direction * acceleration);
    }
}