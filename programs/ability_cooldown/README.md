# Ability Cooldown

## Description
This mechanic will show how to implement Ability Cooldowns.

## Implementation
All instructions will be done within your Ability's C# Script
1. Create "public float cooldownTime = 3;" this will determine the time the ability takes to be ready and can be set within unity, it can be any number.
2. Create "private float nextFireTime = 0;" If you want the ability to not be ready immediately upon starting the game you can change this number.
3. Create "private bool cooldown = false;"
4. Create a private void Update() method if you do not already have one.
5. Within Update(), create an if statement for Time.time > nextFireTime, this is our check to see if the ability is ready.
6. Within that if statement, create another if statement to check cooldown.
7. Inside that if statement, write in: print("Ability Ready!"); cooldown = false;
8. Back to the main if statement, write another if statement for the ability's key press if you do not have one.
9. Within this if statement write "print("Shot Fired! Cooldown In Progress"); cooldown = true;" and "nextFireTime = Time.time + cooldownTime;"

In Summary, what we've done, is within the Update method for your ability, made it so it can only activate once Unity's Time
is past the nextFireTime which is determined whenever the ability is used by adding the current time with the cooldown time.