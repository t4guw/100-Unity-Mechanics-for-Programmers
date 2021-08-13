using UnityEngine;

public class SummonAlly : MonoBehaviour
{
    public GameObject ally;
    public Transform allyFollowLoc;
    float timerStart;
    bool allyFollowing;

    void Start()
    {
        timerStart = Time.time - 5f;
        allyFollowing = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            allyFollowing = true;
            timerStart = Time.time;
        }
        if (allyFollowing)
        {
            if (ally.transform.position != allyFollowLoc.position)
            {
                ally.transform.position = Vector3.MoveTowards(ally.transform.position, allyFollowLoc.position, .01f);
            }
            else
            {
                ally.transform.parent = transform;
            }
        }

        if (Time.time - timerStart > 5)
        {
            allyFollowing = false;
            ally.transform.parent = null;
        }
    }
}