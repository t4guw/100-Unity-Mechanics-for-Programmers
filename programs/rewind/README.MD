# Rewind
## Description
This mechanic shows how to implement rewinding time on objects

## Implementation
1. It is recommend you do this implemenation before you've made a level or objects you want to rewind as one of the scripts made has to be added to every single object you want affected by rewinding.
2. Create a new Script called PointInTime, this will be used to record previous positional data about an object.
3. Create a public Vector3 position, public Quaternion rotation, public Vector2 velocity; and a public float angularVelocity.
4. Create a constructor that takes in Vector3 _position, Quaternion _rotation, Vector2 _velocity, float _angularVelocity and assigns them to the appropriate variable.
Script should look like this:
using UnityEngine;

public class PointInTime
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector2 velocity;
    public float angularVelocity;

    public PointInTime(Vector3 _position, Quaternion _rotation, Vector2 _velocity, float _angularVelocity)
    {
        position = _position;
        rotation = _rotation;
        velocity = _velocity;
        angularVelocity = _angularVelocity;
    }
}
5. Create a new Script called Time and create 3 variables: private bool isRewinding = false, List<PointInTime> pointsInTime, and Rigidbody2D rb.
6. Within the Start method assign pointsInTime to a new Points in time list and assign rb to the game object's Rigidbody:
	pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody2D>();
7. Within Update check GetKeyDown on the key you want to use for rewinding, within this if statement call StartRewinding()
8. Make another if statement to check GetKeyUp on the same key so the game knows when to stop, within this call StopRewinding()
9. Within FixedUpdate make an if statement that checks the isRewinding bool, if true call Rewind(), make an else statement that calls Record()
10. StartRewinding will be initializing the rewind process but Rewind will do the actual rewinding, StopRewinding stops the process, Record records positional data of the object into our PointInTime List.
11. Create a private void Record(), within this make an if statement that checks to see if pointsInTime.Count is greater than 500 (pointsInTime increases everytime FixedUpdate is called which is usually 50 times a second but not always, that means if we do not put a cap on the size then this list can get out of control. 500 is roughly 10 seconds but you may want to tool around to find a time that's good for you)
12. Within that if statement (so if the list size is bigger than 500), Remove the last item in the list:
pointsInTime.RemoveAt(pointsInTime.Count - 1);
13. Then outside of that if statement, insert a new PointInTime object into pointsInTime that is sent: transform.position, transform.rotation, rb.velocity, rb.angularVelocity:
pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation, rb.velocity, rb.angularVelocity));
14. Next create a private void Rewind()
15. Make an if statement that checks if pointsInTime's size is greater than 0.
16. Within that statement, create a new PointInTime object and assign it to the first item in pointsInTime, then update the gameObject's transform and rigidbody with the information from that PointInTime followed by removing that PointInTime from the List:
	    PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            rb.velocity = pointInTime.velocity;
            rb.angularVelocity = pointInTime.angularVelocity;

            pointsInTime.RemoveAt(0);
17. Write an else statement for the if statement and have it call StopRewinding() as if the list is empty, we're done rewinding.
18. Lastly, create private void StartRewind and StopRewind and have StartRewind set isRewinding to True and rb's isKinematic to true and have StopRewind set those to false:
    private void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    private void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
19. Back in Unity make sure you add this to every game object you want to affect and make sure that the game object has a rigidbody2d component.