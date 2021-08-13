using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public float firerate = 0;
    public float damage = 10;

    private float timeToFire = 0;
    Transform firePoint;

    // Start is called before the first frame update
    void Awake()
    {
        firePoint = transform.Find("FirePoint").transform;
        if(firePoint == null)
        {
            Debug.LogError("No FirePoint Found. Is your FirePoint object a child of the GameObject ShootProjectile is attached to?");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(firerate == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        } else
        {
            if (Input.GetKey(KeyCode.Space) && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / firerate;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, Vector2.right, 100);
        Debug.DrawLine(firePointPosition, Vector2.right*100, Color.cyan);
        if(hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            GameObject collision = GameObject.Find(hit.collider.name);
            collision.GetComponent<Shield>().Damage(damage);
        }
    }

}
