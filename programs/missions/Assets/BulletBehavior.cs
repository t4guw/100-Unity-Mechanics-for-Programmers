using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    MissionScript mission;

    void Start()
    {
        mission = GameObject.Find("Mission").GetComponent<MissionScript>();
    }

    void Update()
    {
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collide: " + collision.tag);
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            mission.UpdateMissionCount();
        }
    }
}
