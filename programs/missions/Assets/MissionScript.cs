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