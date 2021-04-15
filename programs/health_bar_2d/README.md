# Health Bar in 2D

## Description
This mechanic shows how to implement a health bar. In this implementation, it will give the option to make the health bar follow the player.

## Implementation
There are several steps that need to be done in the Unity Editor.
1. Have a player, or any other object that will have health.
2. Create an Image UI object. This will serve as the "fill" for the health bar.
3. Create an Empty UI object that will serve as the parent Health Bar container, 
and move the Image from Step 2 as a child to this. Resize the container to the desired size.
4. Go to the anchors for the Fill object, hold the ALT (option for Mac) key, and select the bottom right choice. This will scale the "fill" to the parent container.
5. Add a "slider" *component* (do not create a slider object) to the parent object. Disable interactable, change transition to "none", and navigation to "none." Drag the fill object from step 2 to the "Fill Rect" property. The slider property can now change the size of the fill rectangle.
6. Attach the below code to the Health Bar container object.

        using UnityEngine;
        using UnityEngine.UI;

        public class HealthBar : MonoBehaviour
        {
            public Slider slider;
            public Gradient gradient;
            public Image fill;

            public void SetMaxHealth(int health)
            {
                slider.maxValue = health;
                slider.value = health;

                fill.color = gradient.Evaluate(1f);
            }

            public void SetHealth(int health)
            {
                slider.value = health;
                fill.color = gradient.Evaluate(slider.normalizedValue);
            }
        }
7. From the player object chosen in step 1, call the SetMaxHealth() function, and pass in the desired maximum health. To change health, call the SetHealth() function and pass in the new health value. The below code shows an example.

        using UnityEngine;

        public class Player : MonoBehaviour
        {
            public int maxHealth = 100;
            public int currentHealth;

            public HealthBar healthBar;

            private void Start()
            {
                currentHealth = maxHealth;
                healthBar.SetMaxHealth(maxHealth);
            }

            private void Update()
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentHealth -= 15;
                    healthBar.SetHealth(currentHealth);
                }
            }
        }

8. To make the color of the bar constant, simply change the color property of the fill object. To make a changing gradient (such as green for high health, red for low health), select the gradient variable in the inspector. Click on the markers/arrows on each end and change the colors to the desired colors. To add more colors, add more arrows by clicking under the bar. Change between harsh-changing colors and blending the colors via the dropdown at the top.

9. To keep the health bar static, move its position in the canvas to the desired position and anchor accordingly. To make the health bar follow the player, change the canvas "Render Mode" to "World Space." Scale it down (to around 0.01, 0.01, 0.01) and resize the canvas to fit just the health bar. Reposition to the desired position. Drag the health bar under the player in the hierarchy to make it a child.
