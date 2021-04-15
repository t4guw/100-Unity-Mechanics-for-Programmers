using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = hitPoints;
        actualAlpha = maxAlphaChannel / 255;
    }

    // Update is called once per frame
    void Update()
    {
        ShieldUpdate();
    }

    public void Damage(float dmg)
    {
        currentHitPoints-= dmg;

        if(currentHitPoints < 0)
        {
            currentHitPoints = 0;

            coolDownTimer = Time.time + breakCooldown;

            onCooldown = true;
            GetComponent<Collider2D>().enabled = false;
        } else
        {
            recharging = true;
            rechargeTimer = Time.time + rechargeInterval;
        }

        // Update Alpha Channel
        float alpha = ((currentHitPoints / hitPoints) * actualAlpha);
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, alpha);
    }

    public void ShieldUpdate()
    {
        // Check to see if shield is on cooldown
        if (onCooldown && Time.time > coolDownTimer)
        {
            onCooldown = false;
            recharging = true;
            coolDownTimer = 0;
            GetComponent<Collider2D>().enabled = true;
        } 
        // Check to see if shield is recharging
        else if (recharging && !onCooldown && Time.time > rechargeTimer)
        {
            currentHitPoints += rechargeRate;
            if(currentHitPoints >= hitPoints)
            {
                currentHitPoints = hitPoints;
                recharging = false;
                rechargeTimer = 0;
            } else
            {
                rechargeTimer = Time.time + rechargeInterval;
            }

            // Update Alpha Channel
            float alpha = ((currentHitPoints / hitPoints) * actualAlpha);
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, alpha);
        }
    }
}
