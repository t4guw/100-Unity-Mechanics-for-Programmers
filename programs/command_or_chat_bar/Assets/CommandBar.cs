using UnityEngine;
using UnityEngine.UI;

public class CommandBar : MonoBehaviour
{
    public GameObject commandUI;
    public GameObject commandHistory;
    public GameObject commandBar;
    public GameObject textPrefab;
    Vector3 newChatLoc;
    Text inputText;
    bool commandDisplayed;
    float currentTimeDisplayed = 0f;
    float maxTimeDisplayed = 5f;

    void Start()
    {
        commandBar.GetComponent<InputField>().characterLimit = 60;
        commandUI.SetActive(false);
        inputText = commandBar.transform.GetChild(1).GetComponent<Text>();
        newChatLoc = new Vector3(commandBar.transform.localPosition.x, commandBar.transform.localPosition.y + 30f, 0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            commandUI.SetActive(true);
            commandBar.SetActive(true);
            currentTimeDisplayed = 0f;
            commandDisplayed = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && commandUI.activeInHierarchy)
        {
            commandUI.SetActive(false);
        }

        if (commandDisplayed == true)
        {
            currentTimeDisplayed += Time.deltaTime;
            if (currentTimeDisplayed >= maxTimeDisplayed)
            {
                commandUI.SetActive(false);
                currentTimeDisplayed = 0f;
                commandDisplayed = false;
            }
        }
    }

    public void CommandSent()
    {
        for (int i = 0; i < commandHistory.transform.childCount; i++)
        {
            GameObject child = commandHistory.transform.GetChild(i).gameObject;
            Vector3 childLoc = child.transform.localPosition;
            child.transform.localPosition = new Vector3(childLoc.x, childLoc.y + 30f, 0f);
        }
        GameObject currentText = Instantiate(textPrefab, Vector3.zero, Quaternion.identity);
        currentText.GetComponent<Text>().text = inputText.text;
        currentText.transform.parent = commandHistory.transform;
        currentText.transform.localScale = Vector3.one;
        currentText.transform.localPosition = newChatLoc;
        commandBar.GetComponent<InputField>().text = "";
        commandBar.SetActive(false);
        commandDisplayed = true;
    }
}
