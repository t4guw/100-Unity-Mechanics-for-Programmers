using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public GameObject checkpoints;
    int currentCheckpoint;

    void Start()
    {
        currentCheckpoint = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Checkpoint")
        {
            checkpoints.transform.GetChild(currentCheckpoint).gameObject.SetActive(false);
            currentCheckpoint++;
            if(currentCheckpoint == checkpoints.transform.childCount)
            {
                currentCheckpoint = 0;
            }
            checkpoints.transform.GetChild(currentCheckpoint).gameObject.SetActive(true);
        }
    }
}
