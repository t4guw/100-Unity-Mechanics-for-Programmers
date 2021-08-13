# Change Player Speed

## Description
This mechanic shows how to implement slowing and speeding up a player. This is done
when walking over a certain tile, and also a consumed powerup that lasts for a certain duration.

## Implementation
For each object that will slow the player, create a Sprite Renderer. Add BoxCollider2D components to each, and enable "Is Trigger."
For a constant object that will slow the player only when stepped on, and return to normal after exiting the object, add the following script:
        
        using UnityEngine;

        public class ChangeSpeed : MonoBehaviour
        {
            public float newSpeed;
            private float oldSpeed;

            private void OnTriggerEnter2D(Collider2D collision)
            {
                oldSpeed = collision.GetComponent<Movement>().speed;
                collision.GetComponent<Movement>().speed = newSpeed;
            }

            private void OnTriggerExit2D(Collider2D collision)
            {
                collision.GetComponent<Movement>().speed = oldSpeed;
            }
        }

For a power up that will disappear when stepped on, and apply an effect for a duration,
add the following script:

        using UnityEngine;

        public class PowerUp : MonoBehaviour
        {
            public float newSpeed;
            private float oldSpeed;
            public float duration = 5f;
            private float timeLeft;
            private Movement player = null;
            private bool pickedUp = false;

            private void OnTriggerEnter2D(Collider2D collision)
            {
                player = collision.GetComponent<Movement>();
                oldSpeed = player.speed;
                player.speed = newSpeed;
                timeLeft = duration;
                pickedUp = true;
                this.GetComponent<SpriteRenderer>().enabled = false;
            }

            private void Update()
            {
                if (pickedUp)
                {
                    timeLeft -= Time.deltaTime;
                    if (timeLeft <= 0)
                    {
                        player.speed = oldSpeed;
                        Destroy(this.gameObject);
                    }
                }
            }
        }
