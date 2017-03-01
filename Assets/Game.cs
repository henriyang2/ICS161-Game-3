using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour 
{
    //Script that takes care of game win/end states

    //These UI elements are under the Canvas object in the hierarchy
    //Dragged in from inspector, this is the text that displays once somebody has won
    public GameObject gameEndText;
    //Dragged in from inspector, this is the button that will allow players to restart the game
    public GameObject restartBtn;

    public bool gameEnded = false;

	void Start () 
    {
        //If time was frozen, resume it
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
	}
	
	void Update () 
    {
        
	}

    //For ending the game
    public void EndGame (string winner)
    {
        gameEnded = true;

        //Freeze time once game has ended
        Time.timeScale = 0f;

        //Determine which player won
        gameEndText.GetComponent<Text>().text = winner + " has won!";

        //Display end game screen
        gameEndText.SetActive(true);
        restartBtn.SetActive(true);
    }

    //For restarting the game
    public void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
