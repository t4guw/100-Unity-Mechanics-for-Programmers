using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Playground/Gameplay/Object Shooter")]
[RequireComponent(typeof(AudioSource))]

public class ShooterCooldown : MonoBehaviour
{
    public float cooldownTime = 3;
    public KeyCode keyToPress = KeyCode.Space;
    public float shootSpeed = 5f;
    public Vector2 shootDirection = new Vector2(1f, 1f);
	public bool relativeToRotation = true;
	public GameObject prefabToSpawn;
	public AudioClip soundEffect;
	AudioSource audioSource;

	private float nextFireTime = 0;
	private bool cooldown = false;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void Update()
    {
		if (Time.time > nextFireTime)
		{
			if (cooldown)
			{
				print("Shot Ready!");
				cooldown = false;
			}
			if (Input.GetKey(keyToPress))
			{
				print("Shot Fired! Cooldown In Progress");
				cooldown = true;

				// Borrowed from Unity Playground ObjectShooter Script

				Vector2 actualBulletDirection = (relativeToRotation) ? (Vector2)(Quaternion.Euler(0, 0, transform.eulerAngles.z) * shootDirection) : shootDirection;

				audioSource.PlayOneShot(soundEffect, 0.7F);

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

				nextFireTime = Time.time + cooldownTime;
			}
		}

    }
}
