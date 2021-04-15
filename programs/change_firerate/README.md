# Change Firerate
## Description
This mechanic shows how to change the firerate during gameplay.

## Implementation
This re-uses the Cooldown code from Ability Cooldown for the core firing and delay between shots.

1. Add "public KeyCode speedUp = KeyCode.LeftShift; public KeyCode speedDown = KeyCode.LeftAlt; public KeyCode reset = KeyCode.R; private float currentFirerate;" to the list of variables.
1a. This will be the keys that allow the player to increase, decrease, or reset the firerate of the weapon.
2. Within the Start() method add "currentFirerate = cooldownTime;"
3. Within the Update() method and before the firerate if statements, create an if statement for "Input.GetKeyDown(speedUp) && currentFirerate > 0"
4. Create an Else If statement for "Input.GetKeyDown(speedDown) && currentFirerate < 5"
5. Create an If statement for "Input.GetKeyDown(reset)"
6. Within the speedUp if statement simply add "currentFirerate = currentFirerate - 0.1f;"
7. Within the speedDown if statement simply add "currentFirerate = currentFirerate + 0.1f;"
8. Within the reset if statement simply add "currentFirerate = cooldownTime;"
9. Adjust the Ability Cooldown code to make use of currentFirerate rather than cooldownTime and it will take care of the rest. You could also add a public float for how much the firerate increases/decreases by.