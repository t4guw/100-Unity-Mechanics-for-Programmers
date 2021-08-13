using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] buttons;
    public GameObject gameoverUI;
    public Text countText;

    int count;
    float timer;
    bool gameover;

    void Start()
    {
        count = 0;
        timer = 0f;
        gameover = false;
    }

    void Update()
    {
        if ((Time.time - timer > 0.5f) && !gameover)
        {
            int randIndex = Random.Range(0, 4);
            Instantiate(buttons[randIndex], spawnPoint);
            timer = Time.time;
        }

        if (spawnPoint.childCount > 0 && spawnPoint.GetChild(count).transform.position.y < -5.5f)
        {
            GameOver();
        }

        // Put an if statement for each key here
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (spawnPoint.GetChild(count).tag == "LeftArrow")
            {
                CorrectArrowClicked();
            }
            else
            {
                GameOver();
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (spawnPoint.GetChild(count).tag == "RightArrow")
            {
                CorrectArrowClicked();
            }
            else
            {
                GameOver();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (spawnPoint.GetChild(count).tag == "UpArrow")
            {
                CorrectArrowClicked();
            }
            else
            {
                GameOver();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (spawnPoint.GetChild(count).tag == "DownArrow")
            {
                CorrectArrowClicked();
            }
            else
            {
                GameOver();
            }
        }
    }

    public void CorrectArrowClicked()
    {
        spawnPoint.GetChild(count).GetComponent<SpriteRenderer>().color = Color.green;
        count++;
        countText.text = "Count: " + count;
    }

    void GameOver()
    {
        gameoverUI.SetActive(true);
        gameoverUI.transform.GetChild(1).GetComponent<Text>().text = "Count: " + count;
        Destroy(countText.gameObject);
        Destroy(spawnPoint.gameObject);
        Destroy(this.GetComponent<GameManager>());
    }

}
