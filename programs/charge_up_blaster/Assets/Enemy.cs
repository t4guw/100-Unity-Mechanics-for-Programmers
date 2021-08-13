using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float damageflashtime = 0.5f;
    private float damagetimer = 0;
    private Color original;

    private void Awake()
    {
        original = gameObject.GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        if(damagetimer > 0 && damagetimer < Time.time)
        {
            gameObject.GetComponent<SpriteRenderer>().color = original;
            damagetimer = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        damagetimer = Time.time + damageflashtime;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
