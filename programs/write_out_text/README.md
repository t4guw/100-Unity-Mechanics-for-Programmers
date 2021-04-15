# Write Out Text Effect

## Description
This mechanic shows how to write out a message letter by letter. This effect is commonly found in tutorials and dialogue in games.

## Implementation
Ensure an empty GameObject has been created with a Text/message object as its child.
- Attach the following script to the parent object. The filler text can be replaced by any desired message: 

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

- Attach the following script to the child object. This will serve as the object that will actually write the message:

        using UnityEngine;
        using UnityEngine.UI;

        public class TextWriter : MonoBehaviour
        {
            private Text uiText;
            private string textToWrite;
            private float timePerCharacter;
            private float timer;
            private int characterIndex;
            private bool invisibleCharacters;

            public void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
            {
                this.uiText = uiText;
                this.textToWrite = textToWrite;
                this.timePerCharacter = timePerCharacter;
                this.invisibleCharacters = invisibleCharacters;
                characterIndex = 0;
            }

            private void Update()
            {
                if (uiText != null)
                {
                    timer -= Time.deltaTime;
                    while (timer <= 0f)
                    {
                        timer += timePerCharacter;
                        characterIndex++;
                        string text = textToWrite.Substring(0, characterIndex);

                        if (invisibleCharacters)
                        {
                            text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                        }

                        uiText.text = text;

                        if (characterIndex >= textToWrite.Length)
                        {
                            uiText = null;
                            return;
                        }
                    }
                }
            }
        }
