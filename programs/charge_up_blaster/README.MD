# Charge Up Blaster
## Description
This mechanic shows how to make a charge up ability for a weapon.

## Implementation
This mechanic assumes you're using a projectile prefab based shooting mechanic with a bullet script, although you can likely adjust the code to work with another system.
1. Within your Shooting Script (wherever you check for player input for the fire button and shoot the object) create the following variables:
    public float chargeDelay = 0.2f;
    private float chargeDelayTimer = 0;

    public float maxChargeTime = 5f;

    public int maxChargeDamage = 40;
    private int currentChargeDamage = 0;

    public float maxChargeSize = 0.4f;
    private float currentChargeSize = 0;

    public Color chargeColor;
    private Color originalColor;

    private bool charging = false;
    private float startCharge;

The chargeDelayTimer is to give the player time to just shoot a regular bullet before the charging ability kicks in.
The maxChargeTime is the time in seconds it should take for the weapon to reach full charge.
The maxChargeDamage is the ADDITIONAL maximum damage that is added to the bullet object (In our case the bullet does a default of 10 damage, so a fully charged shot would do 10+40 or 50 damage)
The maxChargeSize is the ADDITIONAL scale of the bullet object
The chargeColor is the color the player gradually changes to as they reach a full charge
The original color is for maintaining the original Color of the player.
2. Within the Start() method assign originalColor to GetComponent<SpriteRenderer>().color so we don't lose the original color when changing it.
3. Within Update() call Fire(), Fire() will be the method that handles the entire shooting mechanic plus the charging mechanic as well as the player's input for shooting
4. Create private void Fire()
5. Within Fire create an if statement to check for KeyDown or ButtonDown for the fire input, in our case: Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F)
6. Within that if statement set chargeDelayTimer to Time.time + chargeDelay
7. Create another if statement to check for KeyUp or ButtonUp on the fire input, in our case: Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.F)
8. Within this if statement do the following:
            chargeDelayTimer = 0;
            startCharge = 0;
            charging = false;

            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            bullet.GetComponent<Bullet>().damage = bullet.GetComponent<Bullet>().damage + currentChargeDamage;
            bullet.transform.localScale = new Vector2(bullet.transform.localScale.x + currentChargeSize, bullet.transform.localScale.y + currentChargeSize);
            GetComponent<SpriteRenderer>().color = originalColor;

            currentChargeDamage = 0;
            currentChargeSize = 0;
If the player releases the fire button before our charge function can begin or during it, we just need to make absolutely sure that the variables used for counting or keeping track of charge progress are reset for the next charge sequence
Which is what all of the = 0 and = false are for.
Additionally, this is also where we launch the bullet and we need to update it if we charged at all (which is why we reset both current variables afterwards.) So we first Instantiate it but have it assigned to an object so we can change the stats before it gets anywhere
In this case we simply add the current Damage and current Size to the damage variable and localScale respectively. We also make sure to return the player to their original color.
9. Next create another if statement to check if chargeDelayTimer is not equal to 0 AND that Time.time is greater than chargeDelayTimer.
10. Within that if statement, set charging to true, startCharge to Time.time, and chargeDelayTimer to 0 (This is necessary to make sure we don't trip the if statement again)
11. Create another if statement to check if charging is true
12. Within that if statement declare a float percent and assign it to 0 and following that create another if statement that checks if (Time.time - startCharge) is less than or equal to maxChargeTime
13. Within the (Time.time - startCharge) <= maxChargeTime if statement, set percent to (Time.time - startCharge) / maxChargeTime, then to (float)(Math.Round((double)percent, 2)) (this rounds the float to 2 decimal places which makes it so that percent can reach 1.0 within the if statement)
14. Following the percent assignments, set currentChargeDamage to maxChargeDamage * percent (make sure to cast as an int!) and currentChargeSize to maxChargeSize * percent, and lastly set GetComponent<SpriteRenderer>().color to Color.Lerp(originalColor, chargeColor, percent)
Color.Lerp returns a Color that is between Color x and Color y based off of float z so 0 for Color x and 1 for Color y
15. Back within the charging == true if statement and right after the (Time.time - startCharge) <= maxChargeTime if statement, put an else statement and inside it set GetComponent<SpriteRenderer>().color to chargeColor
This is because due to some issue, once percent reaches 1.0, for some reason Color.Lerp sets the Color back to the original color, so this else statement ensures the color stays correct.
16. Now you are done, if you encounter issues on integrating this into your Shooting function, feel free to see and or use the scripts provided to see how they work.