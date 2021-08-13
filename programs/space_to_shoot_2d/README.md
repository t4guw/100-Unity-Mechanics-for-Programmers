# Space Bar to Shoot in 2D

## Description
This mechanic shows how to shoot projectiles from a player using the space bar or left mouse button.
However, it can be easily modified to utilize different keys. It builds upon the "WASD Movement"
mechanic. Once implemented it behaves similarly to a Space Invaders player movement.

## Implementation
There are several tasks that need to be done in the Unity Editor to implement this mechanic.
- Create a Player _**GameObject**_ with a Rigidbody 2D component
- Create a Bullet _**prefab**_ a Rigidbody 2D component
- Attach the below code to the player object, then attach the bullet prefab to the Bullet prefab
variable
- Attach the Player GameObject to the Fire Point variable in the editor, or if a custom Fire point is
desired (if wanting to fire from a custom location that is *not* the center of the object), "Create Empty" as a child of the Player GameObject and attach that as the "Fire Point" variable
- To adjust the fire rate/cooldown, modify the "cooldown" variable

### 
    using UnityEngine;
    using UnityEngine.UI;

    public class Player : MonoBehaviour {

        private float speed = 7f;
        private Rigidbody2D rb2d;
        public Transform firePoint;
        public GameObject bulletPrefab;
        private float bulletSpeed = 10f;
        private float cooldown = 0.5f;
        private float nextFire = 0f;

        void Start () {
            rb2d = GetComponent<Rigidbody2D> ();
        }
        
        void Update () {
            UpdateMotion();
            ProcessBulletSpwan();
        }

        private void UpdateMotion() {
            Vector3 pos = transform.position;

            if (Input.GetKey("w"))
            {
                pos.y += speed * Time.deltaTime;
            }

            if (Input.GetKey("s"))
            {
                pos.y -= speed * Time.deltaTime;
            }

            if (Input.GetKey("d"))
            {
                pos.x += speed * Time.deltaTime;
            }

            if (Input.GetKey("a"))
            {
                pos.x -= speed * Time.deltaTime;
            }

            transform.position = pos;
        }
        
        private void ProcessBulletSpwan() {
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && Time.time > nextFire) {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D re = bullet.GetComponent<Rigidbody2D>();
                re.velocity = firePoint.up * bulletSpeed;
                nextFire = Time.time + cooldown;
            }
        }
    }
