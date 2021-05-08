using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{
    public Dropdown sleepDropdown;
    public Dropdown amPmDropdown;

    string amPm;
    public int hours;
    public int minutes;

    void Start()
    {
        hours = 12;
        minutes = 00;
        amPm = "PM";
        InvokeRepeating("UpdateTime", 1f, 1f);
    }

    void UpdateTime()
    {
        if (minutes == 59)
        {
            minutes = 0;
            if (hours == 12)
            {
                hours = 1;
            }
            else
            {
                if (hours == 11)
                {
                    SwapAmPm();
                }
                hours++;
            }
        }
        else
        {
            minutes++;
        }
        this.GetComponent<Text>().text = string.Format("{0:00}:{1:00} " + amPm, hours, minutes);
    }

    void SwapAmPm()
    {
        if (amPm == "PM")
        {
            amPm = "AM";
        }
        else
        {
            amPm = "PM";
        }
    }

    public void PlayerSlept()
    {
        amPm = amPmDropdown.options[amPmDropdown.value].text;
        hours = int.Parse(sleepDropdown.options[sleepDropdown.value].text);
        minutes = 0;
        amPmDropdown.value = 0;
        sleepDropdown.value = 0;
        amPmDropdown.transform.parent.gameObject.SetActive(false);
    }
}
