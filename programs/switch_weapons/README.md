# Switch Weapons

## Description
This mechanic demonstrates how to switch weapons

## Implementation
1. Make sure your weapons are either methods within the same C# Script or accessible via this new one which we will call SwitchWeapons
2. Create a public KeyCode input = KeyCode.Q; and a private bool change = true; and a public KeyCode shoot = KeyCode.Space;
 2a. If you have more than 2 weapons you'll want the change object to be an int so it can change to 0 1 2 3 etc and you may want to have multiple key inputs to switch to a specific weapon.
3. Within the Update method write an if statement for "Input.GetKeyDown(change)"
4. Within that if statement write "currentWeapon = !currentWeapon;"
5. Within the Update method do an else if statement for "Input.GetKeyDown(shoot)"
6. Within that if statement write another if statement to check currentWeapon
7. Within that if statement simply call the weapon method you desire.
8. Write an else statement to call the other weapon method you want.
9. If you have your weapons as their own separate script, you will need to make sure they have a method you can call through a created weapons object within this file.