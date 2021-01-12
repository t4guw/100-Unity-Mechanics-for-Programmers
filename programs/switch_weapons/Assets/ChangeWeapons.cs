using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Playground/Gameplay/Object Shooter")]

public class ChangeWeapons : MonoBehaviour
{
    public GameObject shotgunProjectile;
    public GameObject singleShotProjectile;

	public KeyCode shoot = KeyCode.Space;
    public KeyCode change = KeyCode.Q;

	public float singleShotSpeed = 5f;
	public float shotgunSpeed = 5f;

	public Vector2 shootDirection = new Vector2(1f, 1f);
	private Vector2 shootDirection2 = new Vector2(1f, 1f);
	private Vector2 shootDirection3 = new Vector2(-1f, 1f);
	public bool relativeToRotation = true;

	private bool currentWeapon = true;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(shoot))
		{

			if (currentWeapon)
			{
				SingleShot();
			}
			else Shotgun();
		} else if (Input.GetKeyDown(change))
        {
			currentWeapon = !currentWeapon;
        }
	}
    void Shotgun()
    {
		// Borrowed from Unity Playground ObjectShooter Script

		Vector2 actualBulletDirection1 = (relativeToRotation) ? (Vector2)(Quaternion.Euler(0, 0, transform.eulerAngles.z) * shootDirection) : shootDirection; //Center
		Vector2 actualBulletDirection2 = (relativeToRotation) ? (Vector2)(Quaternion.Euler(0, 0, transform.eulerAngles.z) * shootDirection2) : shootDirection2; // Left
		Vector2 actualBulletDirection3 = (relativeToRotation) ? (Vector2)(Quaternion.Euler(0, 0, transform.eulerAngles.z) * shootDirection3) : shootDirection3; // Right

		GameObject newObject1 = Instantiate<GameObject>(shotgunProjectile);
		newObject1.transform.position = this.transform.position;
		newObject1.transform.eulerAngles = new Vector3(0f, 0f, Utils.Angle(actualBulletDirection1));
		newObject1.tag = "Bullet";

		GameObject newObject2 = Instantiate<GameObject>(shotgunProjectile);
		newObject2.transform.position = this.transform.position;
		newObject2.transform.eulerAngles = new Vector3(1f, 0f, Utils.Angle(actualBulletDirection2));
		newObject2.tag = "Bullet";

		GameObject newObject3 = Instantiate<GameObject>(shotgunProjectile);
		newObject3.transform.position = this.transform.position;
		newObject3.transform.eulerAngles = new Vector3(0f, 0f, Utils.Angle(actualBulletDirection3));
		newObject3.tag = "Bullet";

		// push the created objects, but only if they have a Rigidbody2D
		Rigidbody2D rigidbody2D = newObject1.GetComponent<Rigidbody2D>();
		if (rigidbody2D != null)
		{
			rigidbody2D.AddForce(actualBulletDirection1 * shotgunSpeed, ForceMode2D.Impulse);
			rigidbody2D = newObject2.GetComponent<Rigidbody2D>();
			rigidbody2D.AddForce(actualBulletDirection2 * shotgunSpeed, ForceMode2D.Impulse);
			rigidbody2D = newObject3.GetComponent<Rigidbody2D>();
			rigidbody2D.AddForce(actualBulletDirection3 * shotgunSpeed, ForceMode2D.Impulse);
		}


		// add a Bullet component if the prefab doesn't already have one, and assign the player ID
		BulletAttribute b = newObject1.GetComponent<BulletAttribute>();
		if (b == null)
		{
			b = newObject1.AddComponent<BulletAttribute>();
			newObject2.AddComponent<BulletAttribute>();
			newObject3.AddComponent<BulletAttribute>();
		}
	}

    void SingleShot()
    {
		// Borrowed from Unity Playground ObjectShooter Script

		Vector2 actualBulletDirection = (relativeToRotation) ? (Vector2)(Quaternion.Euler(0, 0, transform.eulerAngles.z) * shootDirection) : shootDirection;

		GameObject newObject = Instantiate<GameObject>(singleShotProjectile);
		newObject.transform.position = this.transform.position;
		newObject.transform.eulerAngles = new Vector3(0f, 0f, Utils.Angle(actualBulletDirection));
		newObject.tag = "Bullet";

		// push the created objects, but only if they have a Rigidbody2D
		Rigidbody2D rigidbody2D = newObject.GetComponent<Rigidbody2D>();
		if (rigidbody2D != null)
		{
			rigidbody2D.AddForce(actualBulletDirection * singleShotSpeed, ForceMode2D.Impulse);
		}

		// add a Bullet component if the prefab doesn't already have one, and assign the player ID
		BulletAttribute b = newObject.GetComponent<BulletAttribute>();
		if (b == null)
		{
			b = newObject.AddComponent<BulletAttribute>();
		}
	}
}

