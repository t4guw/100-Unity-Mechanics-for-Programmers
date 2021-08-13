# Player Turns

## Description
This mechanic shows how to implement taking turns for 2+ players. 

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create an empty gameobject "Players" to be the parent of all the players
   2. Attach the following TurnManager script to the gameobject created in the previous step.
   3. Set all players as children of the "Players" gameobject.
   4. Create an "End Turn" button and set the On Click() to the EndTurn() function.

    using UnityEngine;
    using UnityEngine.UI;

    public class TurnManager : MonoBehaviour
    {
        public Text currentPlayerText;
        GameObject[] players;
        int currentPlayer;

        void Start()
        {
            currentPlayer = 0;
            players = new GameObject[transform.childCount];
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = transform.GetChild(i).gameObject;
            }
        }

        public void EndTurn()
        {
            players[currentPlayer].GetComponent<Movement>().enabled = false;
            currentPlayer++;
            if (currentPlayer == players.Length)
            {
                currentPlayer = 0;
            }
            players[currentPlayer].GetComponent<Movement>().enabled = true;
            currentPlayerText.text = "Current Player: " + players[currentPlayer];
        }
    }