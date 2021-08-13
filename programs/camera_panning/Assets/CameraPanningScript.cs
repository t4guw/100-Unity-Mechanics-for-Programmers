using UnityEngine;
using UnityEngine.UI;

public class CameraPanningScript : MonoBehaviour
{
    [Header("Player")]
    public Transform playerViewpoint;
    public Transform playerCamStart;

    [Header("NPC")]
    public Transform npcViewpoint;
    public Transform npcCamStart;

    [Header("Misc")]
    public Camera cam;
    public Text dialouge;

    float timerStart;
    bool playerView;

    void Start()
    {
        playerView = true;
        timerStart = Time.time;
    }

    void Update()
    {
        if (Time.time - timerStart > 6f)
        {
            timerStart = Time.time;
            if (playerView)
            {
                cam.transform.position = npcCamStart.position;
                cam.transform.eulerAngles = npcCamStart.eulerAngles;
                cam.transform.parent = npcViewpoint.transform;
                dialouge.text = "*NPC Dialouge Here*";
                playerView = false;
            }
            else
            {
                cam.transform.position = playerCamStart.position;
                cam.transform.eulerAngles = playerCamStart.eulerAngles;
                cam.transform.parent = playerViewpoint.transform;
                dialouge.text = "*Player Dialouge Here*";
                playerView = true;
            }
        }
        else if (Time.time - timerStart < 4f)
        {
            if (playerView)
            {
                playerViewpoint.transform.Rotate(0, 20f * Time.smoothDeltaTime, 0);
                cam.transform.position = Vector3.MoveTowards(cam.transform.position, playerViewpoint.position, 0.0005f);
            }
            else
            {
                npcViewpoint.transform.Rotate(0, -20f * Time.smoothDeltaTime, 0);
                cam.transform.position = Vector3.MoveTowards(cam.transform.position, npcViewpoint.position, 0.0005f);
            }
        }
    }
}