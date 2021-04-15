# Energy Shield
## Description
This mechanic shows how a basic energy shield for the player.

## Implementation
1. Create the following variables
    public float hitPoints = 100f;
    public float maxAlphaChannel = 200f;
    public float rechargeRate = 10f;
    public float rechargeInterval = 1f;
    public float breakCooldown = 3f;

    private float currentHitPoints;
    private bool recharging = false;
    private bool onCooldown = false;

    private float coolDownTimer;
    private float rechargeTimer;

    private float actualAlpha;
All fairly self explanatory, maxAlhpaChannel is what the shield should normally look like (shields are typically see through)
Recharge rate is how many hitpoints are restored every rechargeInterval
BreakCooldown is how long the shield is disabled after reaching 0 hitpoints
actualAlpha is simply to translate the 255 value system to Color's 0-1 system.
2. Within the Start method assign currentHitPoints to hitPoints and actualAlpha to maxAlphaChannel / 255
3. Within Update call ShieldUpdate()
4. Create a PUBLIC void Damage method that takes in float dmg.
5. Within Damage subtract the damage to the currentHitPoints, then create an if statement that checks if currentHitPoints is below 0.
6. Within that if statement set the currentHitPoints to 0, set teh coolDownTimer to Time.time + breakCooldown, set onCooldown to true, and disable the collider for the shield: GetComponent<Collider2D>().enabled = false
7. Next create an else statement that sets recharging to true and sets rechargeTimer to Time.time + rechargeInterval
8. Lastly create a float alpha and assign it to this: float alpha = ((currentHitPoints / hitPoints) * actualAlpha) and call GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, alpha)
This calculates what the shield's alpha should be based on the current health and updates the Shield's SpriteRenderer
9. Now create a private void ShieldUpdate (yes I know it's public in the sourcecode, small error but I'd have to rebuild the game)
10. Create an if statement to check if onCooldown is true AND Time.time is greater than coolDownTimer
11. Within that if statement, set onCooldown to false, set recharging to true, set the coolDownTimer to 0 and renable the Collider.
12. Create an else if statement that checks if recharging is true && if onCooldown is false AND Time.time is greater than rechargeTimer
13. Within that else if, add rechargeRate to currentHitPoints, then create an if statement to check if currentHitPoints are equal to or greater than hitPoints, within that set currentHitPoints to hitPoints, recharging to false, and rechargeTimer to 0. Create an else statement for this if statement and set rechargeTimer to Time.time + rechargeInterval
14. Lastly just like in the Damage method, calculate the alpha and update the SpriteRenderer.