using UnityEngine;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour
{
    public AudioSource source;
    private Button button;

    private void Start()
    {
        button = this.GetComponent<Button>();
        source.mute = false;
        ChangeText();
    }

    public void Mute()
    {
        source.mute = !source.mute;
        ChangeText();
    }

    private void ChangeText()
    {
        if (source.mute)
        {
            button.GetComponentInChildren<Text>().text = "Muted";

        }
        else
        {
            button.GetComponentInChildren<Text>().text = "Unmuted";
        }
    }
}
