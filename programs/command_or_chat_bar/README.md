# Command/Chat Bar

## Description
This mechanic shows how to implement a command/chat bar in Unity. The chat UI will disappear 5 seconds after a text is sent to it. 
'C' opens the chat and 'Esc' closes it.

## Implementation
There are several steps that need to be done in the Unity Editor.

   1. Create a canvas and an Empty GameObject in the canvas named Command UI
   2. Create an empty Manager GameObject and attach the following CommandBar script to it.
   3. Use the anchor preset while holding Alt and select the bottom right option for Command UI
   4. Create the following objects as children of Command UI:
	-UI Image (Command Background)
	-Empty GameObject (Command History)
	-Input Field (Command Bar)
   5. Repeat step 2 for the Command History
   6. Set the anchor point of Command Background and Command Bar to the bottom left
   7. Set the image color on the Command Background to desired color that is slightly transparent
   8. Put the Command Bar in the lower left corner with the Command Background directly above it
   9. Drag the Manager object to the "On End Edit" for the Command Bar to have it call CommandSent()
   10. Drag the corresponding objects to the vaariable for the CommandBar script



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

    

    