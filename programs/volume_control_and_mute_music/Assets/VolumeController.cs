using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSource source;
    private Slider slider;

    private void Start()
    {
        slider = this.GetComponent<Slider>();   
    }

    private void Update()
    {
        source.volume = slider.value;
    }
}
