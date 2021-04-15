using UnityEngine;
using UnityEngine.UI;

public class ActivateWriter : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    private Text messageText;

    private void Awake()
    {
        messageText = transform.Find("Message").GetComponent<Text>();
    }

    void Start()
    {
        textWriter.AddWriter(messageText, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec id faucibus enim. " +
            "Curabitur vitae suscipit sapien. Aliquam sit amet mauris a leo fringilla fermentum nec ac lectus. In gravida in est sit amet volutpat.", 0.1f, true);
    }

    
}
