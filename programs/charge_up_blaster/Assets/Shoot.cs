using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firepoint;

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

    public GameObject bulletPrefab;

    private void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
        {
            chargeDelayTimer = Time.time + chargeDelay;
        }
        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.F))
        {
            chargeDelayTimer = 0;
            startCharge = 0;
            charging = false;

            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            bullet.GetComponent<Bullet>().damage = bullet.GetComponent<Bullet>().damage + currentChargeDamage;
            bullet.transform.localScale = new Vector2(bullet.transform.localScale.x + currentChargeSize, bullet.transform.localScale.y + currentChargeSize);
            GetComponent<SpriteRenderer>().color = originalColor;

            currentChargeDamage = 0;
            currentChargeSize = 0;
        }

        if(chargeDelayTimer != 0 && Time.time > chargeDelayTimer)
        {
            charging = true;
            startCharge = Time.time;
            chargeDelayTimer = 0;
        }

        if(charging == true)
        {
            float percent = 0;

            if ((Time.time - startCharge) <= maxChargeTime)
            {
                percent = (Time.time - startCharge) / maxChargeTime;
                percent = (float)(Math.Round((double)percent, 2));
                currentChargeDamage = (int)(maxChargeDamage * percent);
                currentChargeSize = maxChargeSize * percent;

                GetComponent<SpriteRenderer>().color = Color.Lerp(originalColor, chargeColor, percent);
                
            }

            else
            {
                GetComponent<SpriteRenderer>().color = chargeColor;
            }
        }
    }

}
