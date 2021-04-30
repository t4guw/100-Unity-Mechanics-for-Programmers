# Missions

## Description
This mechanic shows how to implement a missions system where the game keeps track of the player's mission progress.

## Implementation
There are several tasks that need to be done in the Unity Editor to implement this mechanic.
   1. Create a Text UI element to keep track of the mission.
   2. Attach the following MissionScript to that Text UI object.
   3. Call UpdateMissionCount() in other scripts when part of the mission is completed.
   4. Change the missionText to reflect the desired mission.

###
    using UnityEngine;
    using UnityEngine.UI;

    public class MissionScript : MonoBehaviour
    {
        int missionReq;
        int missionProg;
        bool missionComplete;
        Text missionText;

        void Start()
        {
            missionReq = Random.Range(4, 10);
            missionProg = 0;
            missionComplete = false;
            missionText = GetComponent<Text>();
            missionText.text = "Mission: " + missionProg + "/" + missionReq + " Enemies Eliminted";
        }

        public void UpdateMissionCount()
        {
            if (missionComplete || (missionProg + 1) == missionReq)
            {
                missionComplete = true;
                missionText.text = "Mission Completed";
            }
            else
            {
                missionProg++;
                missionText.text = "Mission: " + missionProg + "/" + missionReq + " Enemies Eliminted";
            }
        }
    }

