using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public Text time;
    public Vector3 phoneOpenPos;
    public Vector3 phoneClosedPos;
    bool phoneOpen;
    bool phoneMoving;

    void Start()
    {
        phoneOpen = false;
        phoneMoving = false;
        phoneOpenPos = new Vector3(395f, -150f, 0f);
        phoneClosedPos = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            phoneMoving = true;
        }

        if (phoneMoving)
        {
            if (phoneOpen)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, phoneClosedPos, 500f * Time.smoothDeltaTime);
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, phoneOpenPos, 500f * Time.smoothDeltaTime);
            }
        }

        if (transform.localPosition == phoneOpenPos)
        {
            phoneOpen = true;
            phoneMoving = false;
        }
        else if (transform.localPosition == phoneClosedPos)
        {
            phoneOpen = false;
            phoneMoving = false;
        }

        UpdateTime();
    }

    public void UpdateTime()
    {
        int hour = System.DateTime.Now.Hour;
        int minute = System.DateTime.Now.Minute;
        if(hour > 12)
        {
            hour -= 12;
        }
        time.text = string.Format("{0:00}:{1:00}", hour, minute);
    }
}
