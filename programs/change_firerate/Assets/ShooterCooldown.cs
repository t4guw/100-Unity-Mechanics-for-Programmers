using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Playground/Gameplay/Object Shooter")]

public class ShooterCooldown : MonoBehaviour
{
    public float cooldownTime = 1f;
    public KeyCode shootButton = KeyCode.Space;
	public KeyCode speedUp = KeyCode.LeftShift;
	public KeyCode speedDown = KeyCode.LeftAlt;
	public KeyCode reset = KeyCode.R;
	public float shootSpeed = 5f;
    public Vector2 shootDirection = new Vector2(1f, 1f);
	public bool relativeToRotation = true;
	public GameObject prefabToSpawn;

	private float currentFirerate;
	private float nextFireTime = 0;
	private bool cooldown = false;

    private void Start()
    {
		currentFirerate = cooldownTime;
	}

    private void Update()
    {
		if (Input.GetKeyDown(speedUp) && currentFirerate > 0)
		{
			currentFirerate = currentFirerate - 0.1f;
		}
		else if (Input.GetKeyDown(speedDown) && currentFirerate < 5)
		{
			currentFirerate = currentFirerate + 0.1f;
		}

		if (Input.GetKeyDown(reset))
		{
			currentFirerate = cooldownTime;
		}

		if (Time.time > nextFireTime)
		{
			if (cooldown)
			{
				print("Shot Ready!");
				cooldown = false;
			}
			if (Input.GetKey(shootButton))
			{
				print("Shot Fired! Cooldown In Progress");
				cooldown = true;

				// Borrowed from Unity Playground ObjectShooter Script

				Vector2 actualBulletDirection = (relativeToRotation) ? (Vector2)(Quaternion.Euler(0, 0, transform.eulerAngles.z) * shootDirection) : shootDirection;

				GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
				newObject.transform.position = this.transform.position;
				newObject.transform.eulerAngles = new Vector3(0f, 0f, Utils.Angle(actualBulletDirection));
				newObject.tag = "Bullet";

				// push the created objects, but only if they have a Rigidbody2D
				Rigidbody2D rigidbody2D = newObject.GetComponent<Rigidbody2D>();
				if (rigidbody2D != null)
				{
					rigidbody2D.AddForce(actualBulletDirection * shootSpeed, ForceMode2D.Impulse);
				}

				// add a Bullet component if the prefab doesn't already have one, and assign the player ID
				BulletAttribute b = newObject.GetComponent<BulletAttribute>();
				if (b == null)
				{
					b = newObject.AddComponent<BulletAttribute>();
				}

				nextFireTime = Time.time + currentFirerate;
			} 
		}
    }
}
