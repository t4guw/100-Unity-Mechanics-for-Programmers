using UnityEngine;

public class POVScript : MonoBehaviour
{
    Vector3 firstPersonPos;
    Vector3 thirdPersonPos;
    Vector3 thirdPersonRot;
    bool firstPerson;

    void Start()
    {
        firstPersonPos = new Vector3(0, 0.7f, 0);
        thirdPersonPos = new Vector3(-1f, 2f, -3f);
        thirdPersonRot = new Vector3(20f, 0, 0);
        firstPerson = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (firstPerson)
            {
                transform.localPosition = thirdPersonPos;
                transform.localEulerAngles = thirdPersonRot;
                firstPerson = false;
            }
            else
            {
                transform.localPosition = firstPersonPos;
                transform.localEulerAngles = Vector3.zero;
                firstPerson = true;
            }
        }
    }
}
